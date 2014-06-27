using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MARS;

/// <summary>
/// Summary description for DefinidorLEDEER
/// </summary>
public class DefinerLEDEER
{
    private Arena arena; //Para definir elementos dentro de la arena

    //Atributos para 
    private Actor actor;
    private MARS.Object obj;
    private Role role;
    private RoleActancial roleact;
    private ActionMARS action;

        
	public DefinerLEDEER()
	{
        arena = new Arena();
        /*actor = new Actor();
        obj = new Object();
        role = new Role();
        roleact = new RoleActancial();
        action = new Action();*/
    }

    public Arena Arena { 
        set{
        }
        get{return arena;}
    }

    
    public Actor Actor
    {
        set
        {
        }
        get { return actor; }
    }

    //Métodos para agregar elementos
    //Regresan 0 si es agragado correctamente

    public int addActor(string nameactor)
    {
        actor = new Actor(); actor.Name = nameactor;
        //agregar actor
        return actor.addActor();
    }

    //Método get Actors
    public DataSet getActors()
    {
        return new Actor().getActors();
    }

    public int addArena(string namearena)
    {
        arena = new Arena(); arena.Name = namearena;
        //agregar arena
        return arena.addArena();
    }


    public int addAction(string nameaction)
    {
        action = new ActionMARS(); action.Name = nameaction;
        //agregar action
        return action.addAction();
    }

    //Método get Actions
    public DataSet getActions()
    {
        return new ActionMARS().getActions();
    }

    //Método get Arenas
    public DataSet getArenas()
    {
        return new Arena().getArenas();
    }

    //Método get Arena
    public DataSet getArena(int id)
    {
        arena = new Arena();
        arena.Id = id;
        return arena.getArena();
    }

    /// <summary>
    /// Método que regresa la llave de un scenario
    /// </summary>
    /// <param name="namearena"></param>
    /// <param name="namescenario"></param>
    /// <returns></returns>
    public string getScenarioId(string namearena, string namescenario)
    {
        arena = new Arena();
        arena.Name = namearena;
        return arena.getScenarioId(namescenario);
    }



    /// <summary>
    /// Método que regresa la llave de una arena
    /// </summary>
    /// <param name="namearena"></param>
    /// <param name="namescenario"></param>
    /// <returns></returns>
    public string getArenaId(string namearena)
    {
        arena = new Arena();
        arena.Name = namearena;
        return arena.getArenaId();
    }


    /// <summary>
    /// Método para obtener los datos de un escenario
    /// </summary>
    /// <param name="namearena"></param>
    /// <param name="nameaction"></param>
    /// <param name="namescenario"></param>
    /// <returns></returns>
    public DataSet getScenarioData(string namearena, string nameaction,string namescenario)
    {
        arena = new Arena();
        arena.Name = namearena;
        //Obtener datos de la arena
        return arena.getScenarioData(nameaction, namescenario);
    }

    /// <summary>
    /// Método que regresa la llave de un role
    /// </summary>
    /// <param name="namerole"></param>
    /// <returns></returns>
    public string getRoleId(string namerole)
    {
        role  = new Role();
        role.Name = namerole;
        return role.getRoleId();
    }


    /// <summary>
    /// Método que regresa los escenarios de una arena en un dataSet
    /// </summary>
    /// <param name="namerole"></param>
    /// <returns></returns>
    public DataSet getScenariosOfArena(string namearena)
    {
        arena = new Arena();
        arena.Name = namearena;
        return arena.getScenariosOfArena();
    }


    public int addRole(string namerole)
    {
        //Establecer valores
        role = new Role(); role.Name = namerole;
        
        //agregar role
        return role.addRole();
    }

    //Método get Roles
    public DataSet getRoles()
    {
        return new Role().getRoles();
    }

    
    public int addObject(string nameobj,string val)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Name = nameobj; obj.Value = val;

        //agregar objeto
        return obj.addObject();
    }

    //Método get Objects
    public DataSet getObjects()
    {
        return new MARS.Object().getObjects();
    }


    public int addRoleActancial(string nameroleact)
    {
        //Establecer valores
        roleact = new RoleActancial(); roleact.Name = nameroleact;

        //agregar role actancial
        return roleact.addRoleActancial();
    }


    //Método get Roles actanciales
    public DataSet getRolesActancial()
    {
        return new RoleActancial().getRolesActancial();
    }


    //Fin para métodos para agregar y gets 



    //Métodos para eliminar elementos LEDEER
    //Regresan 0 si son eliminados correctamente

    //Con nombre del actor
    public int delActor(string nameactor)
    {
        actor = new Actor(); actor.Name = nameactor;
        //eliminar actor
        return actor.delActor();
    }


    //Con llave del actor
    public int delActor(int idactor)
    {
        actor = new Actor(); actor.Id = idactor;
        //eliminar actor
        return actor.delActor();
    }

    //Eliminar arena con nombre
    public int delArena(string namearena)
    {
        arena = new Arena(); arena.Name = namearena;
        //eliminar arena
        return arena.delArena();
    }

    //Eliminar arena con llave
    public int delArena(int idarena)
    {
        arena = new Arena(); arena.Id = idarena;
        //eliminar arena
        return arena.delArena();
    }



    //Con nombre de la acción
    public int delAction(string nameaction)
    {
        action = new ActionMARS(); action.Name = nameaction;
        //eliminar action
        return action.delAction();
    }


    //Con llave de la acción
    public int delAction(int idaction)
    {
        action = new ActionMARS(); action.Id = idaction;
        //eliminar action
        return action.delAction();
    }

    //Con nombre del role
    public int delRole(string namerole)
    {
        //Establecer valores
        role = new Role(); role.Name = namerole;

        //eliminar role
        return role.delRole();
    }

    //Con llave del role
    public int delRole(int idrole)
    {
        //Establecer valores
        role = new Role(); role.Id = idrole;

        //eliminar role
        return role.delRole();
    }


    //eliminar objeto con nombre
    public int delObject(string nameobj)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Name = nameobj; 

        //eliminar objeto
        return obj.delObject();
    }

    //eliminar objeto con llave
    public int delObject(int idobj)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Id = idobj;

        //eliminar objeto
        return obj.delObject();
    }

    //Eliminar role actancial con nombre del role actancial
    public int delRoleActancial(string nameroleact)
    {
        //Establecer valores
        roleact = new RoleActancial(); roleact.Name = nameroleact;

        //eliminar role actancial
        return roleact.delRoleActancial();
    }


    //Eliminar role actancial con nombre del role actancial
    public int delRoleActancial(int idroleact)
    {
        //Establecer valores
        roleact = new RoleActancial(); roleact.Id = idroleact;

        //eliminar role actancial
        return roleact.delRoleActancial();
    }
    //Los métodos de eliminar regresan 0 si se elimino correctamente
    //Fin para eliminar


    //Métodos para actualizar elementos
    //Regresan diferente de 0 si es modificado correctamente

    public int updateActor(int idactor, string nameactorU)
    {
        actor = new Actor(); actor.Id = idactor; actor.Name = nameactorU;
        //actualizar actor
        return actor.updateActor();
    }


    public int updateArena(int idarena, string namearenaU)
    {
        arena = new Arena(); arena.Id = idarena; arena.Name = namearenaU;
        //actualizar arena
        return arena.updateArena();
    }

    public int updateAction(int idaction, string nameactionU)
    {
        action = new ActionMARS(); action.Id = idaction; action.Name = nameactionU;
        //modificar action
        return action.updateAction();
    }

    public int updateRole(int idrole, string nameroleU)
    {
        //Establecer valores
        role = new Role(); role.Id = idrole; role.Name = nameroleU;

        //modificar role
        return role.updateRole();
    }


    public int updateScenario(int idscenario, string namescenarioU, string descriptionU)
    {
        //Establecer valores
        Scenario scenario = new Scenario(); scenario.Id = idscenario; scenario.Name = namescenarioU; scenario.Description = descriptionU;

        //modificar scenario
        return scenario.updateScenario();
    }
    
    public int updateObject(int idobj, string nameobjU, string valU)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Id = idobj; obj.Name = nameobjU; obj.Value = valU;

        //modificar objeto
        return obj.updateObject();
    }

    public int updateRoleActancial(int idroleact, string nameroleactU)
    {
        //Establecer valores
        roleact = new RoleActancial(); roleact.Id = idroleact; roleact.Name = nameroleactU;

        //Modificar role actancial
        return roleact.updateRoleActancial();
    }
    //Fin para métodos para actualiza o modificar

    //Los métodos update regresan un valor distinto de 0 cuando
    //son modificados correctamente

    //Actualizar sentencia a un escenario usando llave 
    public int updateSentenceOfScenario(int idsentence, string sentences)
    {
        Sentence sentence = new Sentence();
        sentence.Id = idsentence;
        sentence.Sentences = sentences;
        
        return sentence.updateSentence();
    }
    //Actualizar sentencia a un escenario atributo proceso
    public int updateProcessOfSentence(int idsentence, string process)
    {
        Sentence sentence = new Sentence();
        sentence.Process = process;
        return sentence.updateSentenceProcess();
    }

    //Actualizar sentencia a un escenario atributo type
    public int updateTypeOfSentence(int idsentence, string type)
    {
        Sentence sentence = new Sentence();
        sentence.Type = type;
        return sentence.updateSentenceType();
    }


    //Agregar role a actor
    public int addRoleToActor(string namearena, string nameactor,string namerole)
    {
        //Asignar valores
        actor = new Actor(); actor.Name = nameactor;
        role = new Role(); role.Name = namerole;

        return actor.addRoleToActor(namearena,role);
    }

    //agregar actor a una arena con nombres
    public int addActorToArena(string namearena, string nameactor)
    {
        //Construir actor con datos
        actor = new Actor(); actor.Name = nameactor;

        //Contruir arena con dato y llamar método para agregar actor
        arena = new Arena(); arena.Name = namearena;

        return arena.addActorToArena(actor);
    }

    //get actores de una arena con nombres
    public DataSet getActorsOfArena(string namearena)
    {
        //Contruir arena con dato y llamar método para agregar actor
        arena = new Arena(); arena.Name = namearena;

        return arena.getActorsOfArena();
    }


    //agregar action a una arena con nombres
    public int addActionToArena(string namearena, string nameaction)
    {
        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;

        //Contruir arena con dato y llamar método para agregar action
        arena = new Arena(); arena.Name = namearena;

        return arena.addActionToArena(action);

    }

    //get actions de una arena con nombres
    public DataSet getActionsOfArena(string namearena)
    {
        //Contruir arena con dato y llamar método para agregar action
        arena = new Arena(); arena.Name = namearena;

        return arena.getActionsOfArena();

    }


    
    //agregar role a una arena con nombres
    public int addRoleToArena(string namearena, string namerole)
    {
        //Construir action con datos
        role = new Role(); role.Name = namerole;

        //Contruir arena con dato y llamar método para agregar role
        arena = new Arena(); arena.Name = namearena;

        return arena.addRoleToArena(role);

    }

    //get roles de una arena con nombres
    public DataSet getRolesOfArena(string namearena)
    {
        //Contruir arena con dato y llamar método para agregar action
        arena = new Arena(); arena.Name = namearena;

        return arena.getRolesOfArena();

    }


    //agregar objeto a una arena con nombres
    public int addObjectToArena(string namearena, string nameobj)
    {
        //Construir object con datos
        obj = new MARS.Object(); obj.Name = nameobj; 

        //Contruir arena con dato y llamar método para agregar role
        arena = new Arena(); arena.Name = namearena;

        return arena.addObjectToArena(obj);

    }

    //agregar role actancial a una arena con nombres

    public int addRoleActToArena(string namearena, string namerole)
    {
        //Construir object con datos
        roleact = new RoleActancial(); roleact.Name = namerole;

        //Contruir arena con dato y llamar método para agregar role
        arena = new Arena(); arena.Name = namearena;

        return arena.addRoleActToArena(roleact);

    }


    //get objetos de una arena con nombres
    public DataSet getObjectsOfArena(string namearena)
    {
        //Contruir arena con dato y llamar método para agregar action
        arena = new Arena(); arena.Name = namearena;

        return arena.getObjectsOfArena();

    }

    //get roles actanciales de una arena con nombres
    public DataSet getRolesActOfArena(string namearena)
    {
        //Contruir arena con dato y llamar método para agregar action
        arena = new Arena(); arena.Name = namearena;

        return arena.getRolesActOfArena();

    }


    //agregar role actancial a una acción
    
    public int addRoleActToAction(string namearena, string nameaction, string nameroleact)
    {
        //Construir action con datos
        roleact = new RoleActancial(); roleact.Name = nameroleact;

        //Contruir arena con datos y llamar método para agregar role act
        action = new ActionMARS(); action.Name = nameaction;

        return action.addRoleActToAction(namearena,roleact);

    }


    //get role actancial a una acción
    public DataSet getRoleActOfAction(string namearena, string nameaction)
    {
        //Contruir arena con datos y llamar método para agregar role act
        action = new ActionMARS(); action.Name = nameaction;

        return action.getRoleActOfAction(namearena);
    }


    //agregar scenario a una acción

    public int addScenarioToAction(string namearena, string nameaction, string namescenario, string description)
    {
        
        //Construir scenario con datos
        Scenario scenario = new Scenario(); scenario.Name = namescenario; scenario.Description = description;


        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;

        return action.addScenarioToAction(namearena, scenario);
    }


    //Obtinene nombre de scenario de acuerdo a una acción y arena

    public string getScenarioOfAction(string namearena, string nameaction)
    {
        string str = "";
        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;

        DataSet name =  action.getScenarioOfAction(namearena);
        try{
            if (name.Tables.Count >0 && name.Tables[0].Rows.Count > 0)
                str = name.Tables[0].Rows[0]["AtrName"].ToString();

        }catch{;}

        return str;
    }


    public string getScenarioOfActionId(string namearena, string nameaction)
    {
        string str = "0";
        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;

        DataSet name = action.getScenarioOfAction(namearena);
        try
        {
            if (name.Tables.Count > 0 && name.Tables[0].Rows.Count > 0)
                str = name.Tables[0].Rows[0]["IdScenario"].ToString();

        }
        catch { ;}

        return str;
    }


    //Agregar sentencia a un scenario
    public int addSentenceToScenario(string namearena, string namescenario, string sentence, string process, string type)
    {
        //Construir scenario con datos
        Scenario scenario = new Scenario(); 
        scenario.Name = namescenario;

        getScenarioOfAction(namearena, namescenario);
        //getSentencesOfScenario(namearena, namescenario).;


        Sentence sentence1 = new Sentence();
        sentence1.Process = process;
        sentence1.Type = type;
        sentence1.Sentences = sentence;
        return scenario.addSentenceToScenario(namearena,sentence1);
    }




    //get DataSet role de actor en arena
    public string getRoleOfActor(string namearena, string nameactor)
    {
        string str = "";//Cadena a regresar
        //Construir scenario con datos
        arena = new Arena();
        actor = new Actor();

        arena.Name = namearena;
        actor.Name = nameactor;
        try
        {
            DataSet ds = arena.getRoleOfActor(actor);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                str = ds.Tables[0].Rows[0]["AtrNameRole"].ToString();
        }
        catch
        {
        }
        return str;
    }

    
    //get DataSet sentencia a un scenario
    public DataSet getSentencesOfScenario(string namearena,string namescenario)
    {
        //Construir scenario con datos

        Scenario scenario = new Scenario();
        scenario.Name = namescenario;

        return scenario.getSentencesOfScenario(namearena);

    }


    //Eliminar sentencia a un escenario usando llave del escenario
    public int delSentenceOfScenario(int idscenario,int idsentence)
    {
        //Construir scenario con datos
        Scenario scenario = new Scenario();
        scenario.Id = idscenario;

        Sentence sentence = new Sentence();
        sentence.Id = idsentence;

        return scenario.delSentenceOfScenario(sentence);

    }

    //Eliminar sentencia a un escenario usando llave del escenario
    public int delSentenceOfScenario(string namescenario, int idsentence)
    {
        //Construir scenario con datos
        Scenario scenario = new Scenario();
        scenario.Name = namescenario;

        Sentence sentence = new Sentence();
        sentence.Id = idsentence;

        return scenario.delSentenceOfScenario(sentence);

    }

    
    //eliminar scenario a una acción

    public int delScenarioOfAction(string namearena, string nameaction, string namescenario)
    {
        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;
        return action.delScenarioOfAction(namearena,namescenario);
    }


    //Regresa 0 si es agragado correctamente nombre
    public int delActorOfArena(string namearena, string nameactor)
    {
        //Construir actor con datos
        actor = new Actor(); actor.Name = nameactor;

        //Contruir arena con dato y llamar método para eliminar actor
        arena = new Arena(); arena.Name = namearena;

        return arena.delActorOfArena(actor);
    
    }

    // con llaves
    public int delActorOfArena(int namearena, int nameactor)
    {
        //Construir actor con datos
        actor = new Actor(); actor.Id = nameactor;

        //Contruir arena con dato y llamar método para eliminar actor
        arena = new Arena(); arena.Id = namearena;

        return arena.delActorOfArena(actor);
    }

            
    //con nombres
    public int delActionOfArena(string namearena, string nameaction)
    {
        //Construir action con datos
        action = new ActionMARS(); action.Name = nameaction;

        //Contruir arena con dato y llamar método para eliminar action
        arena = new Arena(); arena.Name = namearena;

        return arena.delActionOfArena(action);

    }

    //Eliminar roles actanciales de una arena con dando la arena y nombre del role actancial
    public int delRoleActOfArena(string namearena, string namerole)
    {
        //Construir role actancial con datos
        roleact = new RoleActancial(); roleact.Name = namerole;

        //Contruir arena con dato y llamar método para eliminar action
        arena = new Arena(); arena.Name = namearena;

        return arena.delRoleActOfArena(roleact);

    }

    //con llaves id
    public int delActionOfArena(int namearena, int nameaction)
    {
        //Construir action con datos
        action = new ActionMARS(); action.Id = nameaction;

        //Contruir arena con dato y llamar método para eliminar action
        arena = new Arena(); arena.Id = namearena;

        return arena.delActionOfArena(action);

    }

    //con nombre
    public int delRoleOfArena(string namearena, string namerole)
    {
        //Construir action con datos
        role = new Role(); role.Name = namerole;

        //Contruir arena con dato y llamar método para eliminar role
        arena = new Arena(); arena.Name = namearena;

        return arena.delRoleOfArena(role);

    }


    //con id, llave
    public int delRoleOfArena(int namearena, int namerole)
    {
        //Construir action con datos
        role = new Role(); role.Id = namerole;

        //Contruir arena con dato y llamar método para eliminar role
        arena = new Arena(); arena.Id = namearena;

        return arena.delRoleOfArena(role);

    }

    //ELiminar objeto de la arena con id's llaves
    public int delObjectOfArena(int idarena, int idobj)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Id = idobj;

        //elimnar objeto de la arena
        arena = new Arena(); arena.Id = idarena;

        return arena.delObjectOfArena(obj);
    }


    //ELiminar objeto de la arena con nombre arena, objeto
    public int delObjectOfArena(string namearena, string nameobj)
    {
        //Establecer valores
        obj = new MARS.Object(); obj.Name = nameobj;

        //elimnar objeto de la arena
        arena = new Arena(); arena.Name = namearena;

        return arena.delObjectOfArena(obj);
    }

    //ELiminar role actancial de la acción con id's llaves
    public int delRoleActOfAction(int idarena, int idaction )
    {
        
        //elimnar role act de la action
        action = new ActionMARS(); action.Id = idaction;

        return action.delRoleActOfAction(idarena);
    }

    //ELiminar role actancial de la acción con nombre
    public int delRoleActOfAction(string namearena, string nameaction)
    {

        //elimnar role act de la action
        action = new ActionMARS(); action.Name = nameaction;

        return action.delRoleActOfAction(namearena);
    }

    //ELiminar role de actor
    public int delRoleOfActor(string namearena, string nameactor)
    {

        //elimnar role act de la action
        actor = new Actor(); actor.Name = nameactor;

        return actor.delRoleOfActor(namearena);
    }

}


