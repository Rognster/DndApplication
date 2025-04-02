// src/hooks/useCharacterLogic.ts
import { useEffect, useState } from 'react';
import { ClassData } from '../interfaces/ClassData';
import { RaceData } from '../interfaces/RaceData';
import { RaceAbilityBonus } from '../interfaces/RaceAbilityBonus';
import { ClassSavingThrows } from '../interfaces/ClassSavingThrows';
import { ClassSkills } from '../interfaces/ClassSkills';
import { AttributeKey } from '../types/CharacterType';
import { ClassLevel, Feature, LevelFeature } from '../interfaces/ClassLevel';  // Added LevelFeature import
import { SpellData } from '../interfaces/SpellData';

export function useCharacterLogic() {
    const baseUrl = 'https://rpapi-czd4aub3fzcrd9ce.swedencentral-01.azurewebsites.net/api/';
    const [classes, setClasses] = useState<ClassData[]>([]);
    const [races, setRaces] = useState<RaceData[]>([]);
    const [selectedClass, setSelectedClass] = useState<number | null>(null);
    const [selectedRace, setSelectedRace] = useState<number | null>(null);
    const [unusedAbilityPoints, setUnusedAbilityPoints] = useState(27);
    const [abilityScores, setAbilityScores] = useState({
        str: { baseScore: 8, bonus: 0, modifier: -1 },
        dex: { baseScore: 8, bonus: 0, modifier: -1 },
        con: { baseScore: 8, bonus: 0, modifier: -1 },
        wis: { baseScore: 8, bonus: 0, modifier: -1 },
        int: { baseScore: 8, bonus: 0, modifier: -1 },
        cha: { baseScore: 8, bonus: 0, modifier: -1 },
    });
    const [classSavingThrows, setClassSavingThrows] = useState<ClassSavingThrows[]>([]);
    const [classSkills, setClassSkills] = useState<ClassSkills[]>([]);
    const [PoficiencyBonus] = useState(2);
    const [proficientSkills, setProficientSkills] = useState<string[]>([]);
    const [classLevels, setClassLevels] = useState<ClassLevel[]>([]);
    const [characterLevel, setCharacterLevel] = useState<number>(1);
    const [currentLevelData, setCurrentLevelData] = useState<ClassLevel | null>(null);
    const [currentLevelFeatures, setCurrentLevelFeatures] = useState<Feature[]>([]);
    const [cumulativeFeatures, setCumulativeFeatures] = useState<Feature[]>([]);
    const [spells, setSpells] = useState<SpellData[]>([]);
    const [isLoadingSpells, setIsLoadingSpells] = useState(false);

    // Helper function to fetch data
    const fetchData = async <T,>(url: string, setState: React.Dispatch<React.SetStateAction<T>>) => {
        try {
            const response = await fetch(url);
            if (response.ok) {
                const data = await response.json();
                setState(data);
            } else {
                console.error(`Failed to fetch from ${url}:`, response.statusText);
            }
        } catch (error) {
            console.error(`Error fetching from ${url}:`, error);
        }
    };

    // Fetch initial data (classes, races, and spells)
    useEffect(() => {
        fetchData<ClassData[]>(`${baseUrl}Class/`, setClasses);
        fetchData<RaceData[]>(`${baseUrl}Race/`, setRaces);
        
        // Fetch spells
        const fetchSpells = async () => {
            setIsLoadingSpells(true);
            try {
                const response = await fetch(`${baseUrl}Spells`);
                if (response.ok) {
                    const data: SpellData[] = await response.json();
                    setSpells(data);
                } else {
                    console.error('Failed to fetch spells:', response.statusText);
                }
            } catch (error) {
                console.error('Error fetching spells:', error);
            } finally {
                setIsLoadingSpells(false);
            }
        };
        
        fetchSpells();
    }, []);

    // Fetch class saving throws when selectedClass changes
    useEffect(() => {
        if (selectedClass) {
            // Fetch Class Saving Throws
            fetch(`${baseUrl}ClassSavingThrow/${selectedClass}`)
                .then((response) => response.json())
                .then((data: ClassSavingThrows[]) => setClassSavingThrows(data))
                .catch((error) => console.error("Error fetching saving throws:", error));

            // Fetch Class Skills
            fetch(`${baseUrl}ClassSkill/${selectedClass}`)
                .then((response) => response.json())
                .then((data: ClassSkills[]) => setClassSkills(data))
                .catch((error) => console.error("Error fetching class skills:", error));

            // Fetch Class Levels
            fetch(`${baseUrl}Class/${selectedClass}/levels`)
                .then((response) => response.json())
                .then((data) => {
                    console.log('Class levels API response:', data);
                    
                    if (Array.isArray(data)) {
                        setClassLevels(data);
                        
                        // Get all features for all levels up to and including current level
                        const allFeatures: Feature[] = [];
                        data.filter(level => level.classLevel <= characterLevel).forEach(level => {
                            if (level.features && Array.isArray(level.features)) {
                                allFeatures.push(...level.features);
                            }
                        });
                        
                        setCumulativeFeatures(allFeatures);
                        
                        // Find level data for current character level
                        const levelData = data.find(
                            (level: ClassLevel) => level.classLevel === characterLevel
                        );
                        
                        if (levelData) {
                            setCurrentLevelData(levelData);
                            
                            // Handle features directly in the levelData
                            if (levelData.features && Array.isArray(levelData.features)) {
                                setCurrentLevelFeatures(levelData.features);
                            } 
                            // Handle features in levelFeatures.feature (original structure)
                            else if (levelData.levelFeatures && levelData.levelFeatures.length > 0) {
                                const features: Feature[] = [];
                                levelData.levelFeatures.forEach((levelFeature: LevelFeature) => {
                                    if (levelFeature.feature) {
                                        features.push(levelFeature.feature);
                                    }
                                });
                                setCurrentLevelFeatures(features);
                            } else {
                                setCurrentLevelFeatures([]);
                            }
                        } else {
                            setCurrentLevelData(null);
                            setCurrentLevelFeatures([]);
                        }
                    }
                })
                .catch((error) => console.error("Error fetching class levels:", error));
        }
    }, [selectedClass, characterLevel]);

    // Update current level data when character level changes
    useEffect(() => {
        if (classLevels.length > 0) {
            // Get all features for all levels up to and including current level
            const allFeatures: Feature[] = [];
            classLevels.filter(level => level.classLevel <= characterLevel).forEach(level => {
                if (level.features && Array.isArray(level.features)) {
                    allFeatures.push(...level.features);
                }
            });
            
            setCumulativeFeatures(allFeatures);
            
            const levelData = classLevels.find(level => level.classLevel === characterLevel);
            
            if (levelData) {
                setCurrentLevelData(levelData);
                
                // Handle features directly in the levelData
                if (levelData.features && Array.isArray(levelData.features)) {
                    setCurrentLevelFeatures(levelData.features);
                } 
                // Handle features in levelFeatures.feature (original structure)
                else if (levelData.levelFeatures && levelData.levelFeatures.length > 0) {
                    const features: Feature[] = [];
                    levelData.levelFeatures.forEach((levelFeature: LevelFeature) => {
                        if (levelFeature.feature) {
                            features.push(levelFeature.feature);
                        }
                    });
                    setCurrentLevelFeatures(features);
                } else {
                    setCurrentLevelFeatures([]);
                }
            } else {
                setCurrentLevelData(null);
                setCurrentLevelFeatures([]);
            }
        }
    }, [characterLevel, classLevels]);

    useEffect(() => {
        const updatedScores = calculateSkillModifiers();
        const areScoresEqual = JSON.stringify(updatedScores) === JSON.stringify(abilityScores);

        if (!areScoresEqual) {
            setAbilityScores(updatedScores);
        }
    }, [proficientSkills, PoficiencyBonus]);

    const toggleProficiency = (skillName: string) => {
        setProficientSkills((prev) => {
            if (prev.includes(skillName)) {
                return prev.filter((name) => name !== skillName);
            } else {
                return [...prev, skillName];
            }
        });
    };

    const calculateSkillModifiers = () => {
        return Object.entries(abilityScores).reduce((scores, [key, value]) => {
            const isProficient = proficientSkills.includes(key);
            const proficiencyBonus = isProficient ? PoficiencyBonus : 0;

            scores[key as keyof typeof abilityScores] = {
                ...value,
                modifier: Math.floor((value.baseScore + value.bonus - 10) / 2) + proficiencyBonus,
            };
            return scores;
        }, {} as typeof abilityScores);
    };

    const handleClassChange = (value: number) => {
        setSelectedClass(value);
        setCharacterLevel(1);
    };

    const updateCharacterLevel = (level: number) => {
        setCharacterLevel(level);
    };

    const handleRaceChange = async (value: number) => {
        setSelectedRace(value);

        const baseScores = {
            str: { baseScore: 8, bonus: 0, modifier: -1 },
            dex: { baseScore: 8, bonus: 0, modifier: -1 },
            con: { baseScore: 8, bonus: 0, modifier: -1 },
            wis: { baseScore: 8, bonus: 0, modifier: -1 },
            int: { baseScore: 8, bonus: 0, modifier: -1 },
            cha: { baseScore: 8, bonus: 0, modifier: -1 },
        };

        try {
            const response = await fetch(`${baseUrl}RaceAbilityBonus/${value}`);
            if (response.ok) {
                const bonuses: RaceAbilityBonus[] = await response.json();

                const updatedScores = bonuses.reduce((scores, bonus) => {
                    const ability = bonus.abilityScoreId as keyof typeof baseScores;
                    scores[ability].bonus += bonus.bonus;
                    return scores;
                }, { ...baseScores });

                Object.keys(updatedScores).forEach((key) => {
                    const abilityKey = key as keyof typeof updatedScores;
                    const { baseScore, bonus } = updatedScores[abilityKey];
                    updatedScores[abilityKey].modifier = Math.floor((baseScore + bonus - 10) / 2);
                });

                setAbilityScores(updatedScores);
            } else {
                console.error('Failed to fetch race bonuses:', response.statusText);
            }
        } catch (error) {
            console.error('Error fetching race bonuses:', error);
        }
    };

    const DecreaseAbilityScore = (attr: AttributeKey) => {
        setAbilityScores((prev) => {
            const cost = prev[attr].baseScore > 13 ? 2 : 1;
            if (prev[attr].baseScore > 8) {
                setUnusedAbilityPoints((points) => points + cost);

                const updatedBaseScore = prev[attr].baseScore - 1;
                const updatedModifier = Math.floor((updatedBaseScore + prev[attr].bonus - 10) / 2);

                return {
                    ...prev,
                    [attr]: {
                        ...prev[attr],
                        baseScore: updatedBaseScore,
                        modifier: updatedModifier,
                    },
                };
            }
            return prev;
        });
    };

    const IncreaseAbilityScore = (attr: AttributeKey) => {
        setAbilityScores((prev) => {
            const cost = prev[attr].baseScore >= 13 ? 2 : 1;
            if (unusedAbilityPoints >= cost && prev[attr].baseScore < 15) {
                setUnusedAbilityPoints((points) => points - cost);

                const updatedBaseScore = prev[attr].baseScore + 1;
                const updatedModifier = Math.floor((updatedBaseScore + prev[attr].bonus - 10) / 2);

                return {
                    ...prev,
                    [attr]: {
                        ...prev[attr],
                        baseScore: updatedBaseScore,
                        modifier: updatedModifier,
                    },
                };
            }
            return prev;
        });
    };

    return {
        classes,
        races,
        selectedClass,
        selectedRace,
        abilityScores,
        handleClassChange,
        handleRaceChange,
        DecreaseAbilityScore,
        IncreaseAbilityScore,
        unusedAbilityPoints,
        classSavingThrows,
        PoficiencyBonus,
        classSkills,
        proficientSkills,
        toggleProficiency,
        classLevels,
        characterLevel,
        updateCharacterLevel,
        currentLevelData,
        currentLevelFeatures,
        cumulativeFeatures,
        spells, // Export spells
        isLoadingSpells // Export loading state
    };
}
