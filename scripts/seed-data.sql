-- Demo seed data for YourMusicDepot_Database
-- Run after create-database.sql

SET IDENTITY_INSERT [Instructors] ON;
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (1, N'Marcus', N'Bell', N'Classical Guitar Instructor', N'1112223333', N'marcus.bell@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (2, N'Sarah', N'Whitfield', N'Piano Specialist', N'2223334444', N'sarah.whitfield@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (3, N'Daniel', N'Reyes', N'Electric Guitar Instructor', N'3334445555', N'daniel.reyes@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (4, N'Emily', N'Carter', N'Acoustic Guitar Instructor', N'4445556666', N'emily.carter@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (5, N'James', N'Connor', N'Drums and Percussion', N'5556667777', N'james.connor@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (6, N'Nina', N'Petrova', N'Keyboard Instructor', N'6667778888', N'nina.petrova@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (7, N'Liam', N'Fletcher', N'Flute and Woodwinds', N'7778889999', N'liam.fletcher@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (8, N'Grace', N'Kim', N'Saxophone Instructor', N'8889991111', N'grace.kim@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (9, N'Anthony', N'Russo', N'Violin Instructor', N'9991112222', N'anthony.russo@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (10, N'Maria', N'Santos', N'Vocal Coach', N'1011121314', N'maria.santos@yourmusicdepot.com', NULL);
INSERT INTO [Instructors] ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorCredential], [InstructorPhoneNumber], [InstructorEmail], [ProfilePicturePath]) VALUES (11, N'Ethan', N'Brooks', N'Music Theory Tutor', N'9054298875', N'ethan.brooks@yourmusicdepot.com', NULL);
SET IDENTITY_INSERT [Instructors] OFF;
GO

SET IDENTITY_INSERT [Rooms] ON;
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (1, 2);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (2, 2);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (3, 2);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (4, 2);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (5, 10);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (6, 10);
INSERT INTO [Rooms] ([RoomID], [RoomSize]) VALUES (7, 10);
SET IDENTITY_INSERT [Rooms] OFF;
GO

SET IDENTITY_INSERT [Students] ON;
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (1, N'Jake', N'Thompson', 15, N'1234567890', N'jake.thompson@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (2, N'Mia', N'Rodriguez', 17, N'2345678901', N'mia.rodriguez@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (3, N'Ryan', N'Chen', 16, N'3456789012', N'ryan.chen@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (4, N'Sophie', N'Bennett', 14, N'4567890123', N'sophie.bennett@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (5, N'Lucas', N'Meyer', 18, N'5678901234', N'lucas.meyer@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (6, N'Olivia', N'Hayes', 16, N'6789012345', N'olivia.hayes@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (7, N'Noah', N'Patel', 17, N'7890123456', N'noah.patel@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (8, N'Emma', N'Wilson', 15, N'8901234567', N'emma.wilson@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (9, N'Tyler', N'Nguyen', 18, N'9012345678', N'tyler.nguyen@example.com', N'demo1234', NULL);
INSERT INTO [Students] ([StudentID], [StudentFirstName], [StudentLastName], [StudentAge], [StudentPhoneNumber], [StudentEmail], [StudentAccountPassword], [ProfilePicturePath]) VALUES (10, N'Ava', N'Martinez', 14, N'1122334455', N'ava.martinez@example.com', N'demo1234', NULL);
SET IDENTITY_INSERT [Students] OFF;
GO

SET IDENTITY_INSERT [InstructorAvailability] ON;
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (1, 1, N'Monday', '09:00:00', '12:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (2, 1, N'Wednesday', '14:00:00', '17:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (3, 2, N'Tuesday', '10:00:00', '13:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (4, 2, N'Thursday', '15:00:00', '18:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (5, 3, N'Wednesday', '09:00:00', '12:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (6, 3, N'Friday', '14:00:00', '17:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (7, 4, N'Monday', '13:00:00', '16:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (8, 4, N'Thursday', '09:00:00', '12:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (9, 5, N'Tuesday', '14:00:00', '17:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (10, 5, N'Friday', '10:00:00', '13:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (11, 6, N'Monday', '10:00:00', '13:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (12, 6, N'Thursday', '14:00:00', '17:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (13, 7, N'Tuesday', '09:00:00', '12:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (14, 7, N'Friday', '15:00:00', '18:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (15, 8, N'Wednesday', '10:00:00', '13:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (16, 8, N'Saturday', '09:00:00', '12:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (17, 9, N'Tuesday', '14:00:00', '17:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (18, 9, N'Thursday', '10:00:00', '13:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (19, 10, N'Monday', '15:00:00', '18:00:00', 1);
INSERT INTO [InstructorAvailability] ([AvailabilityID], [InstructorID], [DayOfWeek], [StartTime], [EndTime], [IsRecurring]) VALUES (20, 10, N'Wednesday', '09:00:00', '12:00:00', 1);
SET IDENTITY_INSERT [InstructorAvailability] OFF;
GO

SET IDENTITY_INSERT [MartialArtsLessons] ON;
INSERT INTO [MartialArtsLessons] ([MartialArtsLessonID], [RoomID], [MartialArtsLessonStartDateTime], [MartialArtsLessonEndDateTime], [MartialArtsLessonStatus]) VALUES (1, 5, '2023-11-25T17:00:00', '2023-11-25T19:00:00', N'Scheduled');
INSERT INTO [MartialArtsLessons] ([MartialArtsLessonID], [RoomID], [MartialArtsLessonStartDateTime], [MartialArtsLessonEndDateTime], [MartialArtsLessonStatus]) VALUES (2, 6, '2023-11-26T16:30:00', '2023-11-26T18:30:00', N'Scheduled');
INSERT INTO [MartialArtsLessons] ([MartialArtsLessonID], [RoomID], [MartialArtsLessonStartDateTime], [MartialArtsLessonEndDateTime], [MartialArtsLessonStatus]) VALUES (3, 7, '2023-11-27T15:00:00', '2023-11-27T17:00:00', N'Scheduled');
INSERT INTO [MartialArtsLessons] ([MartialArtsLessonID], [RoomID], [MartialArtsLessonStartDateTime], [MartialArtsLessonEndDateTime], [MartialArtsLessonStatus]) VALUES (4, 5, '2023-11-28T18:00:00', '2023-11-28T20:00:00', N'Scheduled');
INSERT INTO [MartialArtsLessons] ([MartialArtsLessonID], [RoomID], [MartialArtsLessonStartDateTime], [MartialArtsLessonEndDateTime], [MartialArtsLessonStatus]) VALUES (5, 6, '2023-11-29T12:30:00', '2023-11-29T14:30:00', N'Scheduled');
SET IDENTITY_INSERT [MartialArtsLessons] OFF;
GO

SET IDENTITY_INSERT [MusicLessons] ON;
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (1, 1, 2, 1, '2023-11-25T09:00:00', '2023-11-25T10:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (2, 2, 1, 2, '2023-11-25T11:00:00', '2023-11-25T12:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (3, 3, 4, 3, '2023-11-26T13:00:00', '2023-11-26T14:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (4, 4, 3, 4, '2023-11-26T15:00:00', '2023-11-26T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (5, 5, 5, 5, '2023-11-27T10:00:00', '2023-11-27T11:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (6, 6, 6, 6, '2023-11-27T12:00:00', '2023-11-27T13:30:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (7, 7, 7, 7, '2023-11-28T14:00:00', '2023-11-28T15:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (8, 8, 8, 5, '2023-11-28T16:00:00', '2023-11-28T17:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (9, 9, 9, 6, '2023-11-29T09:00:00', '2023-11-29T10:30:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (10, 10, 10, 7, '2023-11-29T11:00:00', '2023-11-29T12:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (11, 1, 5, 1, '2023-11-30T09:00:00', '2023-11-30T10:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (12, 1, 8, 7, '2023-11-30T14:00:00', '2023-11-30T15:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (13, 2, 10, 1, '2023-11-30T10:00:00', '2023-11-30T11:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (14, 2, 5, 6, '2023-11-30T15:00:00', '2023-11-30T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (15, 1, 6, 2, '2023-12-01T09:00:00', '2023-12-01T10:00:00', N'Canceled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (16, 1, 7, 4, '2023-12-01T14:00:00', '2023-12-01T15:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (17, 2, 2, 3, '2023-12-01T10:00:00', '2023-12-01T11:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (18, 2, 3, 7, '2023-12-01T15:00:00', '2023-12-01T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (19, 1, 1, 5, '2023-12-02T09:00:00', '2023-12-02T10:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (20, 1, 4, 6, '2023-12-02T14:00:00', '2023-12-02T15:00:00', N'Canceled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (21, 2, 9, 2, '2023-12-02T10:00:00', '2023-12-02T11:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (22, 2, 8, 4, '2023-12-02T15:00:00', '2023-12-02T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (23, 1, 2, 3, '2023-12-03T09:00:00', '2023-12-03T10:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (24, 1, 10, 7, '2023-12-03T14:00:00', '2023-12-03T15:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (25, 2, 1, 5, '2023-12-03T10:00:00', '2023-12-03T11:00:00', N'Canceled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (26, 2, 6, 6, '2023-12-03T15:00:00', '2023-12-03T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (27, 1, 3, 2, '2023-12-04T09:00:00', '2023-12-04T10:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (28, 1, 5, 4, '2023-12-04T14:00:00', '2023-12-04T15:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (29, 2, 7, 3, '2023-12-04T10:00:00', '2023-12-04T11:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (30, 2, 4, 7, '2023-12-04T15:00:00', '2023-12-04T16:00:00', N'Completed');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (31, 1, 9, 2, '2023-12-07T09:00:00', '2023-12-07T10:00:00', N'Scheduled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (33, 2, 3, 6, '2023-12-07T10:00:00', '2023-12-07T11:00:00', N'Scheduled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (34, 2, 5, 6, '2023-12-07T15:00:00', '2023-12-07T16:00:00', N'Scheduled');
INSERT INTO [MusicLessons] ([MusicLessonID], [InstructorID], [StudentID], [RoomID], [MusicLessonStartDateTime], [MusicLessonEndDateTime], [MusicLessonStatus]) VALUES (35, 1, 3, 1, '2023-12-08T09:00:00', '2023-12-08T10:00:00', N'Scheduled');
SET IDENTITY_INSERT [MusicLessons] OFF;
GO

SET IDENTITY_INSERT [StudentMusicProgress] ON;
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (1, 1, N'Piano', N'Beginner');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (2, 2, N'Violin', N'Intermediate');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (3, 3, N'Guitar', N'Beginner');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (4, 4, N'Drums', N'Advanced');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (5, 5, N'Saxophone', N'Intermediate');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (6, 6, N'Flute', N'Beginner');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (7, 7, N'Cello', N'Advanced');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (8, 8, N'Trumpet', N'Intermediate');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (9, 9, N'Bass Guitar', N'Beginner');
INSERT INTO [StudentMusicProgress] ([StudentMusicProgressID], [StudentID], [StudentInstrument], [StudentSkillLevel]) VALUES (10, 10, N'Harp', N'Advanced');
SET IDENTITY_INSERT [StudentMusicProgress] OFF;
GO

SET IDENTITY_INSERT [MusicLessonPayments] ON;
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (1, 1, 50.0000, '2023-11-25T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (2, 2, 45.0000, '2023-11-25T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (3, 3, 55.0000, '2023-11-26T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (4, 4, 60.0000, '2023-11-26T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (5, 5, 40.0000, '2023-11-27T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (6, 6, 50.0000, '2023-11-27T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (7, 7, 65.0000, '2023-11-28T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (8, 8, 45.0000, '2023-11-28T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (9, 9, 50.0000, '2023-11-29T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (10, 10, 55.0000, '2023-11-29T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (11, 11, 50.0000, '2023-11-30T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (12, 12, 45.0000, '2023-11-30T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (13, 13, 55.0000, '2023-11-30T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (14, 14, 60.0000, '2023-11-30T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (15, 15, 40.0000, '2023-12-01T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (16, 16, 50.0000, '2023-12-01T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (17, 17, 65.0000, '2023-12-01T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (18, 18, 45.0000, '2023-12-01T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (19, 19, 50.0000, '2023-12-02T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (20, 20, 55.0000, '2023-12-02T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (21, 21, 50.0000, '2023-12-03T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (22, 22, 45.0000, '2023-12-03T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (23, 23, 55.0000, '2023-12-03T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (24, 24, 60.0000, '2023-12-03T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (25, 25, 40.0000, '2023-12-04T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (26, 26, 50.0000, '2023-12-04T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (27, 27, 65.0000, '2023-12-04T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (28, 28, 45.0000, '2023-12-04T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (29, 29, 50.0000, '2023-12-07T00:00:00', N'Debit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (30, 30, 55.0000, '2023-12-07T00:00:00', N'Check');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (31, 31, 50.0000, '2023-12-07T00:00:00', N'Credit Card');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (33, 33, 55.0000, '2023-12-08T00:00:00', N'Cash');
INSERT INTO [MusicLessonPayments] ([MusicLessonPaymentID], [MusicLessonID], [MusicLessonPaymentAmount], [MusicLessonPaymentDate], [MusicLessonPaymentType]) VALUES (34, 34, 60.0000, '2023-12-08T00:00:00', N'Credit Card');
SET IDENTITY_INSERT [MusicLessonPayments] OFF;
GO

