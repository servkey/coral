create table Community_Teams(
idteam int identity(1,1) primary key,
name varchar(200),
idactivity int -- should add another relation table rel *<->*
)

create table Object_Weapons(
idweapon int identity(1,1) primary key,
name varchar(100) not null,
rtd float,
atd float,
mdps int,
ap int,
spread  int,
ms int,
eapp int,
aqos int,
maq int
)

create table Object_Items(
iditem int identity(1,1) primary key,
name varchar(200) not null,
spawntime float
)

create table Actor_Players(
idplayer int identity(1,1) primary key,
name varchar(100) not null,
-- default = 0
deaths int,
kills int,
gamesPlayed int,
skill float, /* compound attribute */
-- default null
idteam int,
idrole int
)

create table Roles(
idrole int identity(1,1) primary key,
name varchar(100)
)

create table Tasks(
idtask int identity(1,1) primary key,
name varchar(100)
)

create table Objectives(
idobjective int identity(1,1) primary key,
name varchar(200),
accomplishmentWeight float,
idactivity int
)

create table Goals(
idgoal int identity(1,1) primary key,
name varchar(200),
idactivity int
)

create table Interactions( /* the ones available */
idinteraction int identity(1,1) primary  key,
idplayer int not null, /* Executor */
iditem int,
idweapon int,
idtask int not null, 
idaffectedplayer int, /* should create interaction_has_affectedActor */
idactivity int not null /* should create activity_has_interaction */
)

create table Interaction_Records( /* the ones executing */
idinteraction int,
window int,
recorddate date,
recordtime time,
)

create table Activities(
idactivity int identity(1,1) primary key,
name varchar(100),
)

-- Creating foreign keys 

-- Foreign keys for Teams

ALTER TABLE [dbo].[Community_Teams]
ADD CONSTRAINT [FK_ActivityTea]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])    

-- Foreign keys for Players

ALTER TABLE [dbo].[Actor_Players]
ADD CONSTRAINT [FK_Team]
    FOREIGN KEY ([idteam])
    REFERENCES [dbo].[Community_Teams]
        ([idteam])    
    
ALTER TABLE [dbo].[Actor_Players]
ADD CONSTRAINT [FK_Role]
    FOREIGN KEY ([idrole])
    REFERENCES [dbo].[Roles]
        ([idrole])    
    
-- Foreign keys for interactions

ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Player]
    FOREIGN KEY ([idplayer])
    REFERENCES [dbo].[Actor_Players]
        ([idplayer])    
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Item]
    FOREIGN KEY ([iditem])
    REFERENCES [dbo].[Object_Items]
        ([iditem])    
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Weapon]
    FOREIGN KEY ([idweapon])
    REFERENCES [dbo].[Object_Weapons]
        ([idweapon])    
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Task]
    FOREIGN KEY ([idtask])
    REFERENCES [dbo].[Tasks]
        ([idtask])    
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_AffectedPlayer]
    FOREIGN KEY ([idaffectedplayer])
    REFERENCES [dbo].[Actor_Players]
        ([idplayer])    
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_ActivityInt]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])    
    
-- foreign keys for Interaction_Records

ALTER TABLE [dbo].[Interaction_Records]
ADD CONSTRAINT [FK_Interaction]
    FOREIGN KEY ([idinteraction])
    REFERENCES [dbo].[Interactions]
        ([idinteraction])
        
-- foreign keys for Objectives

ALTER TABLE [dbo].[Objectives]
ADD CONSTRAINT [FK_ActivityObj]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])
        
-- foreign keys for Goals

ALTER TABLE [dbo].[Goals]
ADD CONSTRAINT [FK_ActivityGoa]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])

-- Records insertion

-- Activities

insert into 
    Activities(name) 
values
    ('TeamKeepTheFlag'),
    ('CaptureTheFlag'),
    ('TeamDeathMatch'),
    ('TeamSurvival')

-- Teams

insert into Community_Teams
    (name, idactivity) 
values
    ('TCLA', 1),
    ('RVSF', 1)