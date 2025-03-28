export interface ClassLevel {
    id: number;
    classLevel: number;
    abilityScoreBonuses: number;
    profBonus: number;
    classId: number;
    index: string;
    url: string;
    
    // Direct features array (as shown in your API response)
    features?: Feature[];
    
    // Legacy structure for backward compatibility
    levelFeatures?: LevelFeature[];
    
    // Spellcasting information if applicable
    spellcastingLevels?: SpellcastingLevel[];
    
    // Class-specific values (like rage count, ki points, etc.)
    classSpecifics?: ClassSpecific[];
}

export interface LevelFeature {
    id: number;
    levelId: number;
    featureId: number;
    feature?: Feature;
}

export interface Feature {
    id: number;
    index: string;
    name: string;
    level?: number;      // Keep for backward compatibility
    classLevel?: number; // Add this to match API response
    description: string;
    prerequisites?: string;
    url?: string;
}

export interface SpellcastingLevel {
    id: number;
    levelId: number;
    cantripsKnown: number;
    spellsKnown: number;
    spellSlotsLevel1: number;
    spellSlotsLevel2: number;
    spellSlotsLevel3: number;
    spellSlotsLevel4: number;
    spellSlotsLevel5: number;
    spellSlotsLevel6: number;
    spellSlotsLevel7: number;
    spellSlotsLevel8: number;
    spellSlotsLevel9: number;
}

export interface ClassSpecific {
    id: number;
    levelId: number;
    keyName: string;
    value: string;
    count: number;
}
