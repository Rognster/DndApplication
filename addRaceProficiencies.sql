-- RaceProficiencies INSERT statements
INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'dwarf'), (SELECT id FROM Proficiencies WHERE [index] = 'battleaxes'));

INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'dwarf'), (SELECT id FROM Proficiencies WHERE [index] = 'handaxes'));

INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'dwarf'), (SELECT id FROM Proficiencies WHERE [index] = 'light-hammers'));

INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'dwarf'), (SELECT id FROM Proficiencies WHERE [index] = 'warhammers'));

INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'elf'), (SELECT id FROM Proficiencies WHERE [index] = 'skill-perception'));

INSERT INTO RaceProficiencies (race_id, proficiency_id) 
VALUES ((SELECT id FROM Races WHERE [index] = 'half-orc'), (SELECT id FROM Proficiencies WHERE [index] = 'skill-intimidation'));
