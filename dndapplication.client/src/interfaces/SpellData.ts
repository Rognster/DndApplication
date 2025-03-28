export interface SpellDamage {
    damageType: string;
    damageAtSlotLevel: string;
    damageAtCharacterLevel: string;
}

export interface SpellData {
    id: number;
    spellIndex: string;
    name: string;
    description: string;
    higherLevel: string;
    range: string;
    components: string;
    material: string;
    ritual: boolean;
    duration: string;
    concentration: boolean;
    castingTime: string;
    level: number;
    school: string;
    url: string;
    damage: SpellDamage[];
}

export interface CharacterSpell {
    id: string;
    spellData: SpellData;
    isPrepared: boolean;
}
