INSERT INTO users
	VALUES (1, 'TestUsername', 'TestPassword', '2018-12-15 00:00:00', '2018-12-16 00:00:00', b'0');
    
INSERT INTO userprofiles
	VALUES (1, 'TestName', 12345678, 'TestEmail', '2018-12-15 00:00:00', '2018-12-16 00:00:00', b'0');
    
INSERT INTO ccas
	VALUES (1, 'TestCca', 'TestType', 'TestDescription', 'TestSchedule', 'TestVenue', 'TestContact', 1, '2018-12-15 00:00:00', 1, '2018-12-16 00:00:00', 1, '2018-12-17 00:00:00', b'1');

INSERT INTO events
	VALUES (1, 1, 'TestEvent', 'TestType', 'TestDescription', '2018-12-15 00:00:00', '2018-12-16 00:00:00', 'TestVenue', 10, 'TestContact', 1, '2018-12-15 00:00:00', 1, '2018-12-16 00:00:00', 1, '2018-12-17 00:00:00', b'1');

INSERT INTO ccamemberships
	VALUES (1, 1, 1, '2018-12-15 00:00:00', 1, '2018-12-16 00:00:00', 1, '2018-12-17 00:00:00', b'1');
    
INSERT INTO eventparticipations
	VALUES (1, 1, 1, '2018-12-15 00:00:00', 1, '2018-12-16 00:00:00', 1, '2018-12-17 00:00:00', b'1');