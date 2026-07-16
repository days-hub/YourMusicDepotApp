CREATE TABLE [Instructors] (
    [InstructorID] int NOT NULL IDENTITY,
    [InstructorFirstName] nvarchar(15) NOT NULL,
    [InstructorLastName] nvarchar(15) NOT NULL,
    [InstructorCredential] nvarchar(100) NOT NULL,
    [InstructorPhoneNumber] nvarchar(20) NOT NULL,
    [InstructorEmail] nvarchar(50) NOT NULL,
    [ProfilePicturePath] nvarchar(max) NULL,
    CONSTRAINT [PK_Instructors] PRIMARY KEY ([InstructorID])
);
GO


CREATE TABLE [Rooms] (
    [RoomID] int NOT NULL IDENTITY,
    [RoomSize] int NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([RoomID])
);
GO


CREATE TABLE [Students] (
    [StudentID] int NOT NULL IDENTITY,
    [StudentFirstName] nvarchar(15) NOT NULL,
    [StudentLastName] nvarchar(15) NOT NULL,
    [StudentAge] tinyint NOT NULL,
    [StudentPhoneNumber] nvarchar(20) NOT NULL,
    [StudentEmail] nvarchar(50) NOT NULL,
    [StudentAccountPassword] nvarchar(100) NOT NULL,
    [ProfilePicturePath] nvarchar(max) NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentID])
);
GO


CREATE TABLE [InstructorAvailability] (
    [AvailabilityID] int NOT NULL IDENTITY,
    [InstructorID] int NOT NULL,
    [DayOfWeek] nvarchar(15) NOT NULL,
    [StartTime] time NOT NULL,
    [EndTime] time NOT NULL,
    [IsRecurring] bit NOT NULL,
    CONSTRAINT [PK_InstructorAvailability] PRIMARY KEY ([AvailabilityID]),
    CONSTRAINT [FK_InstructorAvailability_Instructors_InstructorID] FOREIGN KEY ([InstructorID]) REFERENCES [Instructors] ([InstructorID]) ON DELETE CASCADE
);
GO


CREATE TABLE [MartialArtsLessons] (
    [MartialArtsLessonID] int NOT NULL IDENTITY,
    [RoomID] int NOT NULL,
    [MartialArtsLessonStartDateTime] datetime2 NOT NULL,
    [MartialArtsLessonEndDateTime] datetime2 NOT NULL,
    [MartialArtsLessonStatus] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_MartialArtsLessons] PRIMARY KEY ([MartialArtsLessonID]),
    CONSTRAINT [FK_MartialArtsLessons_Rooms_RoomID] FOREIGN KEY ([RoomID]) REFERENCES [Rooms] ([RoomID]) ON DELETE CASCADE
);
GO


CREATE TABLE [MusicLessons] (
    [MusicLessonID] int NOT NULL IDENTITY,
    [InstructorID] int NOT NULL,
    [StudentID] int NOT NULL,
    [RoomID] int NOT NULL,
    [MusicLessonStartDateTime] datetime2 NOT NULL,
    [MusicLessonEndDateTime] datetime2 NOT NULL,
    [MusicLessonStatus] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_MusicLessons] PRIMARY KEY ([MusicLessonID]),
    CONSTRAINT [FK_MusicLessons_Instructors_InstructorID] FOREIGN KEY ([InstructorID]) REFERENCES [Instructors] ([InstructorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_MusicLessons_Rooms_RoomID] FOREIGN KEY ([RoomID]) REFERENCES [Rooms] ([RoomID]) ON DELETE CASCADE,
    CONSTRAINT [FK_MusicLessons_Students_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Students] ([StudentID]) ON DELETE CASCADE
);
GO


CREATE TABLE [StudentMusicProgress] (
    [StudentMusicProgressID] int NOT NULL IDENTITY,
    [StudentID] int NOT NULL,
    [StudentInstrument] nvarchar(50) NOT NULL,
    [StudentSkillLevel] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_StudentMusicProgress] PRIMARY KEY ([StudentMusicProgressID]),
    CONSTRAINT [FK_StudentMusicProgress_Students_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Students] ([StudentID]) ON DELETE CASCADE
);
GO


CREATE TABLE [MusicLessonPayments] (
    [MusicLessonPaymentID] int NOT NULL IDENTITY,
    [MusicLessonID] int NOT NULL,
    [MusicLessonPaymentAmount] money NOT NULL,
    [MusicLessonPaymentDate] datetime2 NOT NULL,
    [MusicLessonPaymentType] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_MusicLessonPayments] PRIMARY KEY ([MusicLessonPaymentID]),
    CONSTRAINT [FK_MusicLessonPayments_MusicLessons_MusicLessonID] FOREIGN KEY ([MusicLessonID]) REFERENCES [MusicLessons] ([MusicLessonID]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_InstructorAvailability_InstructorID] ON [InstructorAvailability] ([InstructorID]);
GO


CREATE INDEX [IX_MartialArtsLessons_RoomID] ON [MartialArtsLessons] ([RoomID]);
GO


CREATE UNIQUE INDEX [IX_MusicLessonPayments_MusicLessonID] ON [MusicLessonPayments] ([MusicLessonID]);
GO


CREATE INDEX [IX_MusicLessons_InstructorID] ON [MusicLessons] ([InstructorID]);
GO


CREATE INDEX [IX_MusicLessons_RoomID] ON [MusicLessons] ([RoomID]);
GO


CREATE INDEX [IX_MusicLessons_StudentID] ON [MusicLessons] ([StudentID]);
GO


CREATE INDEX [IX_StudentMusicProgress_StudentID] ON [StudentMusicProgress] ([StudentID]);
GO


