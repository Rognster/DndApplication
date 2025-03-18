// src/hooks/useCharacterLogic.ts
import { useEffect, useState } from 'react';
import { ClassData } from '../interfaces/ClassData';
import { RaceData } from '../interfaces/RaceData';
import { RaceAbilityBonus } from '../interfaces/RaceAbilityBonus';
import { ClassSavingThrows } from '../interfaces/ClassSavingThrows';
import { ClassSkills } from '../interfaces/ClassSkills';
import { AttributeKey } from '../types/CharacterType';  // Added import

export function useCharacterLogic() {
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

    // Fetch initial data (classes and races)
    useEffect(() => {
        fetchData<ClassData[]>('https://localhost:5001/api/Class/', setClasses);
        fetchData<RaceData[]>('https://localhost:5001/api/Race/', setRaces);
    }, []);

    // Fetch class saving throws when selectedClass changes
    useEffect(() => {
        if (selectedClass) {
            // Fetch Class Saving Throws
            fetch(`https://localhost:5001/api/ClassSavingThrow/${selectedClass}`)
                .then((response) => response.json())
                .then((data: ClassSavingThrows[]) => setClassSavingThrows(data))
                .catch((error) => console.error("Error fetching saving throws:", error));

            // Fetch Class Skills
            fetch(`https://localhost:5001/api/ClassSkill/${selectedClass}`)
                .then((response) => response.json())
                .then((data: ClassSkills[]) => setClassSkills(data))
                .catch((error) => console.error("Error fetching class skills:", error));
        }
    }, [selectedClass]);

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
                // Remove proficiency
                return prev.filter((name) => name !== skillName);
            } else {
                // Add proficiency
                return [...prev, skillName];
            }
        });
    };

    const calculateSkillModifiers = () => {
        return Object.entries(abilityScores).reduce((scores, [key, value]) => {
            const isProficient = proficientSkills.includes(key); // Check if the skill is proficient
            const proficiencyBonus = isProficient ? PoficiencyBonus : 0;

            scores[key as keyof typeof abilityScores] = {
                ...value,
                modifier: Math.floor((value.baseScore + value.bonus - 10) / 2) + proficiencyBonus,
            };
            return scores;
        }, {} as typeof abilityScores);
    };

    // Handle class change
    const handleClassChange = (value: number) => {
        setSelectedClass(value);
    };

    const handleRaceChange = async (value: number) => {
        setSelectedRace(value);

        // Reset scores to base values
        const baseScores = {
            str: { baseScore: 8, bonus: 0, modifier: -1 },
            dex: { baseScore: 8, bonus: 0, modifier: -1 },
            con: { baseScore: 8, bonus: 0, modifier: -1 },
            wis: { baseScore: 8, bonus: 0, modifier: -1 },
            int: { baseScore: 8, bonus: 0, modifier: -1 },
            cha: { baseScore: 8, bonus: 0, modifier: -1 },
        };

        try {
            const response = await fetch(`https://localhost:5001/api/RaceAbilityBonus/${value}`);
            if (response.ok) {
                const bonuses: RaceAbilityBonus[] = await response.json();

                // Apply race bonuses
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
            const cost = prev[attr].baseScore > 13 ? 2 : 1; // Determine cost
            if (prev[attr].baseScore > 8) { // Ensure baseScore doesn't go below 8
                setUnusedAbilityPoints((points) => points + cost); // Refund points

                const updatedBaseScore = prev[attr].baseScore - 1;
                const updatedModifier = Math.floor((updatedBaseScore + prev[attr].bonus - 10) / 2);

                return {
                    ...prev,
                    [attr]: {
                        ...prev[attr],
                        baseScore: updatedBaseScore, // Update baseScore
                        modifier: updatedModifier,  // Update modifier
                    },
                };
            }
            return prev;
        });
    };

    const IncreaseAbilityScore = (attr: AttributeKey) => {
        setAbilityScores((prev) => {
            const cost = prev[attr].baseScore >= 13 ? 2 : 1; // Determine cost
            if (unusedAbilityPoints >= cost && prev[attr].baseScore < 15) { // Ensure within limits
                setUnusedAbilityPoints((points) => points - cost); // Deduct points

                const updatedBaseScore = prev[attr].baseScore + 1;
                const updatedModifier = Math.floor((updatedBaseScore + prev[attr].bonus - 10) / 2);

                return {
                    ...prev,
                    [attr]: {
                        ...prev[attr],
                        baseScore: updatedBaseScore, // Update baseScore
                        modifier: updatedModifier,  // Update modifier
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
    };
}
