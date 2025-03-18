export interface CharacterType {
    id: number;
    name: string;
    class: string;
    background: string;
    player: string;
    race: string;
    alignment: string;
    experiencepoints: number;
    abilityScores: AbilityScores;
    proficiencybonus: number;
    speed: number;
    inspiration: boolean;
    maxhp: number;
    currenthp: number;
    temphp: number;
    features: string;
    savingThrows: {
        [key in AttributeKey]: {
            value: number;
            isProficient: boolean;
        };
    };
    skills: {
        [key: string]: {
            value: number;
            isProficient: boolean;
            attribute: AttributeKey;
        };
    };
    deathSaves: {
        successes: boolean[];
        failures: boolean[];
    };
    hitDice: {
        total: string;
        remaining: string;
    };
    personality: string;
    ideals: string;
    bonds: string;
    flaws: string;
    otherprofs: string;
    passiveperception: number;
    ac: number;
    initiative: number;
    totalhd: string;
    remaininghd: string;
}

export type AttributeKey = 'str' | 'dex' | 'con' | 'wis' | 'int' | 'cha';

export interface AbilityScores {
    str: number;
    dex: number;
    con: number;
    wis: number;
    int: number;
    cha: number;
}