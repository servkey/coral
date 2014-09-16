
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2014 13:34:27
-- Generated from EDMX file: C:\Users\santigm\Git\Coral\OSAX\WebApplication1\WebApplication1\Modelo\osax.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [osaxx];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Actividad__F_ID___300424B4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK__Actividad__F_ID___300424B4];
GO
IF OBJECT_ID(N'[dbo].[FK__Actividad__F_ID___398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK__Actividad__F_ID___398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__Actividad__ID_Ca__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades] DROP CONSTRAINT [FK__Actividad__ID_Ca__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__Actores__F_ID_AC__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actores] DROP CONSTRAINT [FK__Actores__F_ID_AC__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK__Actores__F_ID_Ca__15502E78]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actores] DROP CONSTRAINT [FK__Actores__F_ID_Ca__15502E78];
GO
IF OBJECT_ID(N'[dbo].[FK__Actores__F_ID_Co__164452B1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actores] DROP CONSTRAINT [FK__Actores__F_ID_Co__164452B1];
GO
IF OBJECT_ID(N'[dbo].[FK__Categoria__ID_Ca__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categorias] DROP CONSTRAINT [FK__Categoria__ID_Ca__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__Comunidad__ID_Ca__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comunidades] DROP CONSTRAINT [FK__Comunidad__ID_Ca__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Metas__ID_Caso__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Metas] DROP CONSTRAINT [FK__Metas__ID_Caso__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Objetivos__F_ID__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetivos] DROP CONSTRAINT [FK__Objetivos__F_ID__1ED998B2];
GO
IF OBJECT_ID(N'[dbo].[FK__Objetivos__ID_Ca__4316F928]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetivos] DROP CONSTRAINT [FK__Objetivos__ID_Ca__4316F928];
GO
IF OBJECT_ID(N'[dbo].[FK__Objetos__F_ID__0CBAE877]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetos] DROP CONSTRAINT [FK__Objetos__F_ID__0CBAE877];
GO
IF OBJECT_ID(N'[dbo].[FK__Objetos__ID_Caso__440B1D61]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objetos] DROP CONSTRAINT [FK__Objetos__ID_Caso__440B1D61];
GO
IF OBJECT_ID(N'[dbo].[FK__Reglas__ID_Caso__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reglas] DROP CONSTRAINT [FK__Reglas__ID_Caso__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__RolesDeAc__ID_Ca__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolesDeActor] DROP CONSTRAINT [FK__RolesDeAc__ID_Ca__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__RolesDeOb__ID_Ca__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolesDeObjeto] DROP CONSTRAINT [FK__RolesDeOb__ID_Ca__46E78A0C];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__F_ID_CA__24927208]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__F_ID_CA__24927208];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__F_ID_OB__37A5467C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__F_ID_OB__37A5467C];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__F_ID_OBJ__38996AB5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__F_ID_OBJ__38996AB5];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__F_ID_RA__267ABA7A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__F_ID_RA__267ABA7A];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__F_ID_RO__25869641]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__F_ID_RO__25869641];
GO
IF OBJECT_ID(N'[dbo].[FK__Tareas__ID_Caso__47DBAE45]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tareas] DROP CONSTRAINT [FK__Tareas__ID_Caso__47DBAE45];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Actividades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actividades];
GO
IF OBJECT_ID(N'[dbo].[Actores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actores];
GO
IF OBJECT_ID(N'[dbo].[CasosEstudio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CasosEstudio];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Comunidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comunidades];
GO
IF OBJECT_ID(N'[dbo].[Metas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Metas];
GO
IF OBJECT_ID(N'[dbo].[Objetivos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objetivos];
GO
IF OBJECT_ID(N'[dbo].[Objetos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objetos];
GO
IF OBJECT_ID(N'[dbo].[Reglas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reglas];
GO
IF OBJECT_ID(N'[dbo].[RolesDeActor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolesDeActor];
GO
IF OBJECT_ID(N'[dbo].[RolesDeObjeto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolesDeObjeto];
GO
IF OBJECT_ID(N'[dbo].[Tareas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tareas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actividades'
CREATE TABLE [dbo].[Actividades] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [F_ID_ME] int  NULL,
    [F_ID_COM] int  NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Actores'
CREATE TABLE [dbo].[Actores] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [F_ID_Cat] int  NULL,
    [F_ID_Com] int  NULL,
    [F_ID_AC] int  NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Comunidades'
CREATE TABLE [dbo].[Comunidades] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Metas'
CREATE TABLE [dbo].[Metas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Objetivos'
CREATE TABLE [dbo].[Objetivos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [F_ID] int  NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Objetos'
CREATE TABLE [dbo].[Objetos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [F_ID] int  NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Reglas'
CREATE TABLE [dbo].[Reglas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'RolesDeActor'
CREATE TABLE [dbo].[RolesDeActor] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'RolesDeObjeto'
CREATE TABLE [dbo].[RolesDeObjeto] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [atributos] varchar(255)  NOT NULL,
    [F_ID_OB] int  NULL,
    [F_ID_CA] int  NULL,
    [F_ID_RO] int  NULL,
    [F_ID_RA] int  NULL,
    [F_ID_OBJETIVO] int  NULL,
    [nombre] varchar(255)  NULL,
    [ID_Caso] int  NULL
);
GO

-- Creating table 'CasosEstudio'
CREATE TABLE [dbo].[CasosEstudio] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NULL,
    [contraseña] varchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [PK_Actividades]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [PK_Actores]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Comunidades'
ALTER TABLE [dbo].[Comunidades]
ADD CONSTRAINT [PK_Comunidades]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [PK_Metas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [PK_Objetivos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [PK_Objetos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Reglas'
ALTER TABLE [dbo].[Reglas]
ADD CONSTRAINT [PK_Reglas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RolesDeActor'
ALTER TABLE [dbo].[RolesDeActor]
ADD CONSTRAINT [PK_RolesDeActor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RolesDeObjeto'
ALTER TABLE [dbo].[RolesDeObjeto]
ADD CONSTRAINT [PK_RolesDeObjeto]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CasosEstudio'
ALTER TABLE [dbo].[CasosEstudio]
ADD CONSTRAINT [PK_CasosEstudio]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [F_ID_ME] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK__Actividad__F_ID___300424B4]
    FOREIGN KEY ([F_ID_ME])
    REFERENCES [dbo].[Metas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actividad__F_ID___300424B4'
CREATE INDEX [IX_FK__Actividad__F_ID___300424B4]
ON [dbo].[Actividades]
    ([F_ID_ME]);
GO

-- Creating foreign key on [F_ID_AC] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK__Actores__F_ID_AC__34C8D9D1]
    FOREIGN KEY ([F_ID_AC])
    REFERENCES [dbo].[Actividades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actores__F_ID_AC__34C8D9D1'
CREATE INDEX [IX_FK__Actores__F_ID_AC__34C8D9D1]
ON [dbo].[Actores]
    ([F_ID_AC]);
GO

-- Creating foreign key on [F_ID_Cat] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK__Actores__F_ID_Ca__15502E78]
    FOREIGN KEY ([F_ID_Cat])
    REFERENCES [dbo].[Categorias]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actores__F_ID_Ca__15502E78'
CREATE INDEX [IX_FK__Actores__F_ID_Ca__15502E78]
ON [dbo].[Actores]
    ([F_ID_Cat]);
GO

-- Creating foreign key on [F_ID_Com] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK__Actores__F_ID_Co__164452B1]
    FOREIGN KEY ([F_ID_Com])
    REFERENCES [dbo].[Comunidades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actores__F_ID_Co__164452B1'
CREATE INDEX [IX_FK__Actores__F_ID_Co__164452B1]
ON [dbo].[Actores]
    ([F_ID_Com]);
GO

-- Creating foreign key on [F_ID] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [FK__Objetos__F_ID__0CBAE877]
    FOREIGN KEY ([F_ID])
    REFERENCES [dbo].[Categorias]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Objetos__F_ID__0CBAE877'
CREATE INDEX [IX_FK__Objetos__F_ID__0CBAE877]
ON [dbo].[Objetos]
    ([F_ID]);
GO

-- Creating foreign key on [F_ID_CA] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__F_ID_CA__24927208]
    FOREIGN KEY ([F_ID_CA])
    REFERENCES [dbo].[Categorias]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__F_ID_CA__24927208'
CREATE INDEX [IX_FK__Tareas__F_ID_CA__24927208]
ON [dbo].[Tareas]
    ([F_ID_CA]);
GO

-- Creating foreign key on [F_ID] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [FK__Objetivos__F_ID__1ED998B2]
    FOREIGN KEY ([F_ID])
    REFERENCES [dbo].[Metas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Objetivos__F_ID__1ED998B2'
CREATE INDEX [IX_FK__Objetivos__F_ID__1ED998B2]
ON [dbo].[Objetivos]
    ([F_ID]);
GO

-- Creating foreign key on [F_ID_OBJETIVO] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__F_ID_OBJ__38996AB5]
    FOREIGN KEY ([F_ID_OBJETIVO])
    REFERENCES [dbo].[Objetivos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__F_ID_OBJ__38996AB5'
CREATE INDEX [IX_FK__Tareas__F_ID_OBJ__38996AB5]
ON [dbo].[Tareas]
    ([F_ID_OBJETIVO]);
GO

-- Creating foreign key on [F_ID_OB] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__F_ID_OB__37A5467C]
    FOREIGN KEY ([F_ID_OB])
    REFERENCES [dbo].[Objetos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__F_ID_OB__37A5467C'
CREATE INDEX [IX_FK__Tareas__F_ID_OB__37A5467C]
ON [dbo].[Tareas]
    ([F_ID_OB]);
GO

-- Creating foreign key on [F_ID_RA] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__F_ID_RA__267ABA7A]
    FOREIGN KEY ([F_ID_RA])
    REFERENCES [dbo].[RolesDeActor]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__F_ID_RA__267ABA7A'
CREATE INDEX [IX_FK__Tareas__F_ID_RA__267ABA7A]
ON [dbo].[Tareas]
    ([F_ID_RA]);
GO

-- Creating foreign key on [F_ID_RO] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__F_ID_RO__25869641]
    FOREIGN KEY ([F_ID_RO])
    REFERENCES [dbo].[RolesDeObjeto]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__F_ID_RO__25869641'
CREATE INDEX [IX_FK__Tareas__F_ID_RO__25869641]
ON [dbo].[Tareas]
    ([F_ID_RO]);
GO

-- Creating foreign key on [F_ID_COM] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK__Actividad__F_ID___398D8EEE]
    FOREIGN KEY ([F_ID_COM])
    REFERENCES [dbo].[Comunidades]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actividad__F_ID___398D8EEE'
CREATE INDEX [IX_FK__Actividad__F_ID___398D8EEE]
ON [dbo].[Actividades]
    ([F_ID_COM]);
GO

-- Creating foreign key on [ID_Caso] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK__Actividad__ID_Ca__48CFD27E]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Actividad__ID_Ca__48CFD27E'
CREATE INDEX [IX_FK__Actividad__ID_Ca__48CFD27E]
ON [dbo].[Actividades]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [FK__Categoria__ID_Ca__403A8C7D]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Categoria__ID_Ca__403A8C7D'
CREATE INDEX [IX_FK__Categoria__ID_Ca__403A8C7D]
ON [dbo].[Categorias]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Comunidades'
ALTER TABLE [dbo].[Comunidades]
ADD CONSTRAINT [FK__Comunidad__ID_Ca__412EB0B6]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Comunidad__ID_Ca__412EB0B6'
CREATE INDEX [IX_FK__Comunidad__ID_Ca__412EB0B6]
ON [dbo].[Comunidades]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [FK__Metas__ID_Caso__4222D4EF]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Metas__ID_Caso__4222D4EF'
CREATE INDEX [IX_FK__Metas__ID_Caso__4222D4EF]
ON [dbo].[Metas]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [FK__Objetivos__ID_Ca__4316F928]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Objetivos__ID_Ca__4316F928'
CREATE INDEX [IX_FK__Objetivos__ID_Ca__4316F928]
ON [dbo].[Objetivos]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [FK__Objetos__ID_Caso__440B1D61]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Objetos__ID_Caso__440B1D61'
CREATE INDEX [IX_FK__Objetos__ID_Caso__440B1D61]
ON [dbo].[Objetos]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Reglas'
ALTER TABLE [dbo].[Reglas]
ADD CONSTRAINT [FK__Reglas__ID_Caso__44FF419A]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Reglas__ID_Caso__44FF419A'
CREATE INDEX [IX_FK__Reglas__ID_Caso__44FF419A]
ON [dbo].[Reglas]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'RolesDeActor'
ALTER TABLE [dbo].[RolesDeActor]
ADD CONSTRAINT [FK__RolesDeAc__ID_Ca__45F365D3]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__RolesDeAc__ID_Ca__45F365D3'
CREATE INDEX [IX_FK__RolesDeAc__ID_Ca__45F365D3]
ON [dbo].[RolesDeActor]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'RolesDeObjeto'
ALTER TABLE [dbo].[RolesDeObjeto]
ADD CONSTRAINT [FK__RolesDeOb__ID_Ca__46E78A0C]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__RolesDeOb__ID_Ca__46E78A0C'
CREATE INDEX [IX_FK__RolesDeOb__ID_Ca__46E78A0C]
ON [dbo].[RolesDeObjeto]
    ([ID_Caso]);
GO

-- Creating foreign key on [ID_Caso] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK__Tareas__ID_Caso__47DBAE45]
    FOREIGN KEY ([ID_Caso])
    REFERENCES [dbo].[CasosEstudio]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__Tareas__ID_Caso__47DBAE45'
CREATE INDEX [IX_FK__Tareas__ID_Caso__47DBAE45]
ON [dbo].[Tareas]
    ([ID_Caso]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------