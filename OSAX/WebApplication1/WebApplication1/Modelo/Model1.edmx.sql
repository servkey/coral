
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2014 11:30:11
-- Generated from EDMX file: C:\Users\santigm\Git\Coral\OSAX\WebApplication1\WebApplication1\Modelo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OSAX];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Comunidades'
CREATE TABLE [dbo].[Comunidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Atributos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Actores'
CREATE TABLE [dbo].[Actores] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Categoria_id] int  NOT NULL,
    [Actividad_id] int  NOT NULL,
    [Comunidad_id] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- Creating table 'Reglas'
CREATE TABLE [dbo].[Reglas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Objetos'
CREATE TABLE [dbo].[Objetos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Categoria_id] int  NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Actividades'
CREATE TABLE [dbo].[Actividades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Meta_id] int  NOT NULL,
    [Comunidad_id] int  NULL
);
GO

-- Creating table 'Metas'
CREATE TABLE [dbo].[Metas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Actividad_id] int  NOT NULL
);
GO

-- Creating table 'Objetivos'
CREATE TABLE [dbo].[Objetivos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Meta_id] int  NOT NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Objetivo_id] int  NOT NULL,
    [Categoria_id] int  NOT NULL
);
GO

-- Creating table 'RolObjetoEstablecer'
CREATE TABLE [dbo].[RolObjetoEstablecer] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaComunidades'
CREATE TABLE [dbo].[InstanciaComunidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Atributos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InstanciaActores'
CREATE TABLE [dbo].[InstanciaActores] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Rol_id] int  NOT NULL,
    [Categoria_id] int  NOT NULL,
    [InstanciaActividad_id] int  NOT NULL,
    [Comunidad_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaRolesActor'
CREATE TABLE [dbo].[InstanciaRolesActor] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaObjetos'
CREATE TABLE [dbo].[InstanciaObjetos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Rol_id] int  NOT NULL,
    [Categoria_id] int  NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaCategorias'
CREATE TABLE [dbo].[InstanciaCategorias] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InstanciaActividades'
CREATE TABLE [dbo].[InstanciaActividades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Meta_id] int  NOT NULL,
    [Comunidad_id] int  NULL
);
GO

-- Creating table 'InstanciaMetas'
CREATE TABLE [dbo].[InstanciaMetas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Actividad_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaObjetivos'
CREATE TABLE [dbo].[InstanciaObjetivos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Meta_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaTareas'
CREATE TABLE [dbo].[InstanciaTareas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [atributos] nvarchar(max)  NOT NULL,
    [Objetivo_id] int  NOT NULL,
    [Categoria_id] int  NOT NULL
);
GO

-- Creating table 'InstanciaRolObjetos'
CREATE TABLE [dbo].[InstanciaRolObjetos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Tarea_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Comunidades'
ALTER TABLE [dbo].[Comunidades]
ADD CONSTRAINT [PK_Comunidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [PK_Actores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Reglas'
ALTER TABLE [dbo].[Reglas]
ADD CONSTRAINT [PK_Reglas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [PK_Objetos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [PK_Actividades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [PK_Metas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [PK_Objetivos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'RolObjetoEstablecer'
ALTER TABLE [dbo].[RolObjetoEstablecer]
ADD CONSTRAINT [PK_RolObjetoEstablecer]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaComunidades'
ALTER TABLE [dbo].[InstanciaComunidades]
ADD CONSTRAINT [PK_InstanciaComunidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaActores'
ALTER TABLE [dbo].[InstanciaActores]
ADD CONSTRAINT [PK_InstanciaActores]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaRolesActor'
ALTER TABLE [dbo].[InstanciaRolesActor]
ADD CONSTRAINT [PK_InstanciaRolesActor]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaObjetos'
ALTER TABLE [dbo].[InstanciaObjetos]
ADD CONSTRAINT [PK_InstanciaObjetos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaCategorias'
ALTER TABLE [dbo].[InstanciaCategorias]
ADD CONSTRAINT [PK_InstanciaCategorias]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaActividades'
ALTER TABLE [dbo].[InstanciaActividades]
ADD CONSTRAINT [PK_InstanciaActividades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaMetas'
ALTER TABLE [dbo].[InstanciaMetas]
ADD CONSTRAINT [PK_InstanciaMetas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaObjetivos'
ALTER TABLE [dbo].[InstanciaObjetivos]
ADD CONSTRAINT [PK_InstanciaObjetivos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaTareas'
ALTER TABLE [dbo].[InstanciaTareas]
ADD CONSTRAINT [PK_InstanciaTareas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InstanciaRolObjetos'
ALTER TABLE [dbo].[InstanciaRolObjetos]
ADD CONSTRAINT [PK_InstanciaRolObjetos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Comunidad_id] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK_ComunidadActor]
    FOREIGN KEY ([Comunidad_id])
    REFERENCES [dbo].[Comunidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComunidadActor'
CREATE INDEX [IX_FK_ComunidadActor]
ON [dbo].[Actores]
    ([Comunidad_id]);
GO

-- Creating foreign key on [Comunidad_id] in table 'Actividades'
ALTER TABLE [dbo].[Actividades]
ADD CONSTRAINT [FK_ActividadesDeLaComunidad]
    FOREIGN KEY ([Comunidad_id])
    REFERENCES [dbo].[Comunidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadesDeLaComunidad'
CREATE INDEX [IX_FK_ActividadesDeLaComunidad]
ON [dbo].[Actividades]
    ([Comunidad_id]);
GO

-- Creating foreign key on [Meta_id] in table 'Objetivos'
ALTER TABLE [dbo].[Objetivos]
ADD CONSTRAINT [FK_MetaDelObjetivo]
    FOREIGN KEY ([Meta_id])
    REFERENCES [dbo].[Metas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaDelObjetivo'
CREATE INDEX [IX_FK_MetaDelObjetivo]
ON [dbo].[Objetivos]
    ([Meta_id]);
GO

-- Creating foreign key on [Objetivo_id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_ObjetivoDeLaTarea]
    FOREIGN KEY ([Objetivo_id])
    REFERENCES [dbo].[Objetivos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetivoDeLaTarea'
CREATE INDEX [IX_FK_ObjetivoDeLaTarea]
ON [dbo].[Tareas]
    ([Objetivo_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_CategoriaDeLaTarea]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[Categorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaDeLaTarea'
CREATE INDEX [IX_FK_CategoriaDeLaTarea]
ON [dbo].[Tareas]
    ([Categoria_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [FK_ObjetosEnLaTarea]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[Tareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetosEnLaTarea'
CREATE INDEX [IX_FK_ObjetosEnLaTarea]
ON [dbo].[Objetos]
    ([Tarea_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_RolActorDeLaTarea]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[Tareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolActorDeLaTarea'
CREATE INDEX [IX_FK_RolActorDeLaTarea]
ON [dbo].[Roles]
    ([Tarea_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'RolObjetoEstablecer'
ALTER TABLE [dbo].[RolObjetoEstablecer]
ADD CONSTRAINT [FK_RolObjetoDeLaTarea]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[Tareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolObjetoDeLaTarea'
CREATE INDEX [IX_FK_RolObjetoDeLaTarea]
ON [dbo].[RolObjetoEstablecer]
    ([Tarea_id]);
GO

-- Creating foreign key on [Actividad_id] in table 'Metas'
ALTER TABLE [dbo].[Metas]
ADD CONSTRAINT [FK_MetaDeLaActividad]
    FOREIGN KEY ([Actividad_id])
    REFERENCES [dbo].[Actividades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaDeLaActividad'
CREATE INDEX [IX_FK_MetaDeLaActividad]
ON [dbo].[Metas]
    ([Actividad_id]);
GO

-- Creating foreign key on [Comunidad_id] in table 'InstanciaActores'
ALTER TABLE [dbo].[InstanciaActores]
ADD CONSTRAINT [FK_ComunidadActor1]
    FOREIGN KEY ([Comunidad_id])
    REFERENCES [dbo].[InstanciaComunidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComunidadActor1'
CREATE INDEX [IX_FK_ComunidadActor1]
ON [dbo].[InstanciaActores]
    ([Comunidad_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'InstanciaActores'
ALTER TABLE [dbo].[InstanciaActores]
ADD CONSTRAINT [FK_CategoriaDelActor1]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[InstanciaCategorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaDelActor1'
CREATE INDEX [IX_FK_CategoriaDelActor1]
ON [dbo].[InstanciaActores]
    ([Categoria_id]);
GO

-- Creating foreign key on [Comunidad_id] in table 'InstanciaActividades'
ALTER TABLE [dbo].[InstanciaActividades]
ADD CONSTRAINT [FK_ActividadesDeLaComunidad1]
    FOREIGN KEY ([Comunidad_id])
    REFERENCES [dbo].[InstanciaComunidades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadesDeLaComunidad1'
CREATE INDEX [IX_FK_ActividadesDeLaComunidad1]
ON [dbo].[InstanciaActividades]
    ([Comunidad_id]);
GO

-- Creating foreign key on [Meta_id] in table 'InstanciaObjetivos'
ALTER TABLE [dbo].[InstanciaObjetivos]
ADD CONSTRAINT [FK_MetaDelObjetivo1]
    FOREIGN KEY ([Meta_id])
    REFERENCES [dbo].[InstanciaMetas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaDelObjetivo1'
CREATE INDEX [IX_FK_MetaDelObjetivo1]
ON [dbo].[InstanciaObjetivos]
    ([Meta_id]);
GO

-- Creating foreign key on [Objetivo_id] in table 'InstanciaTareas'
ALTER TABLE [dbo].[InstanciaTareas]
ADD CONSTRAINT [FK_ObjetivoDeLaTarea1]
    FOREIGN KEY ([Objetivo_id])
    REFERENCES [dbo].[InstanciaObjetivos]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetivoDeLaTarea1'
CREATE INDEX [IX_FK_ObjetivoDeLaTarea1]
ON [dbo].[InstanciaTareas]
    ([Objetivo_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'InstanciaTareas'
ALTER TABLE [dbo].[InstanciaTareas]
ADD CONSTRAINT [FK_CategoriaDeLaTarea1]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[InstanciaCategorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaDeLaTarea1'
CREATE INDEX [IX_FK_CategoriaDeLaTarea1]
ON [dbo].[InstanciaTareas]
    ([Categoria_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'InstanciaObjetos'
ALTER TABLE [dbo].[InstanciaObjetos]
ADD CONSTRAINT [FK_CategoriaDelObjeto1]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[InstanciaCategorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaDelObjeto1'
CREATE INDEX [IX_FK_CategoriaDelObjeto1]
ON [dbo].[InstanciaObjetos]
    ([Categoria_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'InstanciaObjetos'
ALTER TABLE [dbo].[InstanciaObjetos]
ADD CONSTRAINT [FK_ObjetosEnLaTarea1]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[InstanciaTareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetosEnLaTarea1'
CREATE INDEX [IX_FK_ObjetosEnLaTarea1]
ON [dbo].[InstanciaObjetos]
    ([Tarea_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'InstanciaRolesActor'
ALTER TABLE [dbo].[InstanciaRolesActor]
ADD CONSTRAINT [FK_RolActorDeLaTarea1]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[InstanciaTareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolActorDeLaTarea1'
CREATE INDEX [IX_FK_RolActorDeLaTarea1]
ON [dbo].[InstanciaRolesActor]
    ([Tarea_id]);
GO

-- Creating foreign key on [Tarea_id] in table 'InstanciaRolObjetos'
ALTER TABLE [dbo].[InstanciaRolObjetos]
ADD CONSTRAINT [FK_RolObjetoDeLaTarea1]
    FOREIGN KEY ([Tarea_id])
    REFERENCES [dbo].[InstanciaTareas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RolObjetoDeLaTarea1'
CREATE INDEX [IX_FK_RolObjetoDeLaTarea1]
ON [dbo].[InstanciaRolObjetos]
    ([Tarea_id]);
GO

-- Creating foreign key on [Actividad_id] in table 'InstanciaMetas'
ALTER TABLE [dbo].[InstanciaMetas]
ADD CONSTRAINT [FK_MetaDeLaActividad1]
    FOREIGN KEY ([Actividad_id])
    REFERENCES [dbo].[InstanciaActividades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaDeLaActividad1'
CREATE INDEX [IX_FK_MetaDeLaActividad1]
ON [dbo].[InstanciaMetas]
    ([Actividad_id]);
GO

-- Creating foreign key on [InstanciaActividad_id] in table 'InstanciaActores'
ALTER TABLE [dbo].[InstanciaActores]
ADD CONSTRAINT [FK_InstanciaActividadInstanciaActor]
    FOREIGN KEY ([InstanciaActividad_id])
    REFERENCES [dbo].[InstanciaActividades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstanciaActividadInstanciaActor'
CREATE INDEX [IX_FK_InstanciaActividadInstanciaActor]
ON [dbo].[InstanciaActores]
    ([InstanciaActividad_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'Objetos'
ALTER TABLE [dbo].[Objetos]
ADD CONSTRAINT [FK_CategoriadeObjeto]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[Categorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriadeObjeto'
CREATE INDEX [IX_FK_CategoriadeObjeto]
ON [dbo].[Objetos]
    ([Categoria_id]);
GO

-- Creating foreign key on [Categoria_id] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK_CategoriadeActor]
    FOREIGN KEY ([Categoria_id])
    REFERENCES [dbo].[Categorias]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriadeActor'
CREATE INDEX [IX_FK_CategoriadeActor]
ON [dbo].[Actores]
    ([Categoria_id]);
GO

-- Creating foreign key on [Actividad_id] in table 'Actores'
ALTER TABLE [dbo].[Actores]
ADD CONSTRAINT [FK_ActividaddeActor]
    FOREIGN KEY ([Actividad_id])
    REFERENCES [dbo].[Actividades]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividaddeActor'
CREATE INDEX [IX_FK_ActividaddeActor]
ON [dbo].[Actores]
    ([Actividad_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------