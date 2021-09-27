create database roughp2v3;

create table Users(
	UserID int primary key identity,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(50) not null,
	DOB Datetime not null
);

create table Games(
	GameID int primary key identity,
	GameName nvarchar(100) not null,
	GameDescription varchar(300) not null
);

create table Subscriptions(
	SubscriptionID int primary key identity,
	GameID INT NOT NULL FOREIGN KEY REFERENCES Games(GameID) ON DELETE CASCADE,
	UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
);

create table Platforms(
	PlatformID int primary key identity,
	PlatformName nvarchar(40) not null
);

create table Logins(
	Username nvarchar(15) primary key,
	[Password] nvarchar(20) not null,
	UserID int not null FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE
);

create table GamesPlatforms(
	GamePlatformID int primary key identity,
	GameID INT NOT NULL FOREIGN KEY REFERENCES Games(GameID) ON DELETE CASCADE,
	PlatformID INT NOT NULL FOREIGN KEY REFERENCES Platforms(PlatformID) ON DELETE CASCADE
);

create table SubscriptionsDiscussions(
	SubscriptionsDiscussionsID int primary key identity,
	SubscriptionID INT NOT NULL FOREIGN KEY REFERENCES Subscriptions(SubscriptionID) ON DELETE CASCADE
);

create table Discussions(
	DiscussionsID int primary key identity,
	DiscussionsDate Datetime not null,
	DiscussionsTitle nvarchar(50) not null,
	DiscussionsContext nvarchar(500) not null,
	SubscriptionsDiscussionsID INT NOT NULL FOREIGN KEY REFERENCES SubscriptionsDiscussions(SubscriptionsDiscussionsID) ON DELETE CASCADE
);

--Note: UserID does NOT contain ON DELETE CASCADE
create table DiscussionReplies(
	DiscussionRepliesID int primary key identity,
	DiscussionRepliesContext nvarchar(500) not null,
	UserID int not null FOREIGN KEY REFERENCES Users(UserID),
	DiscussionsID int not null FOREIGN KEY REFERENCES Discussions(DiscussionsID) ON DELETE CASCADE
);

create table SubscriptionsComments(
	SubscriptionsCommentsID int primary key identity,
	SubscriptionID INT NOT NULL FOREIGN KEY REFERENCES Subscriptions(SubscriptionID) ON DELETE CASCADE
);

create table Comments(
	CommentsID int primary key identity,
	CommentsContext nvarchar(500) not null,
	CommentsRating bit not null,
	SubscriptionsCommentsID INT NOT NULL FOREIGN KEY REFERENCES SubscriptionsComments(SubscriptionsCommentsID) ON DELETE CASCADE
);