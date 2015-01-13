create table Community_Teams(
idteam int identity(1,1) primary key,
name varchar(200),
idactivity int
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
deaths int,
kills int,
gamesPlayed int,
skill float, /* compound attribute */
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
accomplishmentWeight float
)

create table Goals(
idgoal int identity(1,1) primary key,
name varchar(200)
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
ADD CONSTRAINT [FK_Activity]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Foreign keys for Players

ALTER TABLE [dbo].[Actor_Players]
ADD CONSTRAINT [FK_Team]
    FOREIGN KEY ([idteam])
    REFERENCES [dbo].[Community_Teams]
        ([idteam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Actor_Players]
ADD CONSTRAINT [FK_Role]
    FOREIGN KEY ([idrole])
    REFERENCES [dbo].[Roles]
        ([idrole])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
-- Foreign keys for interactions

ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Player]
    FOREIGN KEY ([idplayer])
    REFERENCES [dbo].[Actor_Players]
        ([idplayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Item]
    FOREIGN KEY ([iditem])
    REFERENCES [dbo].[Object_Items]
        ([iditem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Weapon]
    FOREIGN KEY ([idweapon])
    REFERENCES [dbo].[Object_Weapons]
        ([idweapon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Task]
    FOREIGN KEY ([idtask])
    REFERENCES [dbo].[Tasks]
        ([idtask])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_AffectedPlayer]
    FOREIGN KEY ([idaffectedplayer])
    REFERENCES [dbo].[Actor_Players]
        ([idplayer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [FK_Activity]
    FOREIGN KEY ([idactivity])
    REFERENCES [dbo].[Activities]
        ([idactivity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
    
-- foreign keys for Interaction_Records

ALTER TABLE [dbo].[Interaction_Records]
ADD CONSTRAINT [FK_Interaction]
    FOREIGN KEY ([idinteraction])
    REFERENCES [dbo].[Interactions]
        ([idinteraction])
    ON DELETE NO ACTION ON UPDATE NO ACTION;