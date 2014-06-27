using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

//using BusinessLogic;
[WebService(Namespace = "http://ledeer.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

        
    
    ///<summary>
    ///Métodos del definerLEDEER
    /// </summary>

    //Los métodos para agregar y eliminar regresar el valor 0 si se realiza correctamente
    //Los métodos para actualizar regresan distinto de 0 si son modificados 
    //Agregar actor a LEDEER
    [WebMethod]
    public bool addActor(string nameactor)
    {
        if  (new LogicaNegocio().Ledeer().DefinitionLEDEER().addActor(nameactor) == 0 )
            return true;
        return false;
    }

    //Get actores de LEDEER
    [WebMethod]
    public DataSet getActors()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getActors();
    }


    //Agregar arena a LEDEER
    [WebMethod]
    public bool addArena(string namearena)
    {
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addArena(namearena) == 0)
            return true;
        return false;
    }

    [WebMethod]
    //Método para obtener Arenas
    public DataSet getArenas()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getArenas();
    }

    [WebMethod]
    //Método para obtener nombre de Arena
    public DataSet getArena(int id)
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getArena(id);
    }

    //Agregar funcionalidad a LEDEER
    [WebMethod]
    public int addFunctionality(string nameaction)
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().addAction(nameaction);
    }
    
    //Método para obtener funcionalidades
    [WebMethod]
    public DataSet getAllFunctionality()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getActions();
    }


    //Agregar Role a LEDEER
    [WebMethod]
    public bool addRole(string namerole)
    {
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRole(namerole) == 0)
            return true;
        return false;
    }

    //Método obtener Roles de LEDEEER
    [WebMethod]
    public DataSet getRoles()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getRoles();
    }


    //Agregar objeto a LEDEER
    [WebMethod]     
    public bool addObject(string nameobj, string val)
    {
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addObject(nameobj, val) == 0)
            return true;
         return false;
    }

    //Método get Objects obtener objetos
    [WebMethod]     
    public DataSet getObjects()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getObjects();
    }

    //Agregar rol actancial a LEDEER
    [WebMethod]     
    public bool addRoleActancial(string nameroleact)
    {
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleActancial(nameroleact) == 0)
            return true;
        return false;
    }


    //Método get Roles actanciales
    [WebMethod]
    public DataSet getRolesActancial()
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getRolesActancial();
    }


    //Método get id arena
    [WebMethod]
    public string getArenaId(string name)
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getArenaId(name);
    }


    //Agregar role a actor
    [WebMethod]
    public bool addRoleToActor(string namearena, string nameactor, string namerole)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleToActor(namearena, nameactor, namerole);
        if (res == 0)
            return true;

        return false;
    }

    //agregar actor a una arena con nombres
    [WebMethod]
    public bool addActorToArena(string namearena, string nameactor)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().addActorToArena(namearena, nameactor);
        if (res == 0)
            return true;

        return false;
    }

    //get actores de una arena con nombres
    [WebMethod]
    public DataSet getActorsOfArena(string namearena)
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getActorsOfArena(namearena);

    }

    //get DataSet role de actor en arena
    [WebMethod]
    public string getRoleOfActor(string namearena, string nameactor)
    {
        return new LogicaNegocio().Ledeer().DefinitionLEDEER().getRoleOfActor(namearena, nameactor);
    }

    
    //Regresan 0 si son eliminados correctamente
    //Con nombre del actor
    [WebMethod]
    public bool delActor(string nameactor)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delActor(nameactor);
        if (res == 0)
            return true;
        
        return false;
    }


    //Eliminar actor con llave del actor
    [WebMethod]
    public bool delActorId(int idactor)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delActor(idactor);
        if (res == 0)
            return true;
        
        return false;
    }

    //Eliminar arena con nombre
    [WebMethod]
    public bool delArena(string namearena)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delArena(namearena);
        if (res == 0)
            return true;
        return false;
    }

   // Eliminar arena con llave
   [WebMethod]
   public bool delArenaId(int idarena)
   {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delArena(idarena);
        if (res == 0)
            return true;
        return false;
   }

    
    //Con nombre de la acción
    [WebMethod]
    public bool delFunctionality(string nameaction)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delAction(nameaction);
        if (res == 0)
            return true;
        return false;
    }

    //Con llave de la acción eliminarla
    [WebMethod]
    public bool delFunctionalityId(int idaction)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delAction(idaction);
        if (res == 0)
            return true;
        return false;
    }

    //Eliminar role con nombre
    [WebMethod]
    public bool delRole(string namerole)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delRole(namerole);
        if (res == 0)
            return true;
        return false;
    }


    //Eliminar con llave el role
    [WebMethod]
    public bool delRoleId(int idrole)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delRole(idrole);

        if (res == 0)
            return true;
        return false;
    }


    //Eliminar objeto con nombre
    [WebMethod]
    public bool delObject(string nameobj)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delObject(nameobj);

        if (res == 0)
            return true;
        return false;
    }

    //Eliminar objeto con llave
    [WebMethod]
    public bool delObjectId(int idobj)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delObject(idobj);

        if (res == 0)
            return true;

        return false;
    }

    //Eliminar role actancial con nombre del role actancial
    [WebMethod]
    public bool delRoleActancial(string nameroleact)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delRoleActancial(nameroleact);

        if (res == 0)
            return true;

        return false;
    }

    //Eliminar role actancial con nombre del role actancial
    [WebMethod]
    public bool delRoleActancialId(int idroleact)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().delRoleActancial(idroleact);
        if (res == 0)
            return true;
        return false;
    }



    //Métodos para actualizar elementos
    //Regresan true si es modificado correctamente

    //Modificar actor
    [WebMethod]
    public bool updateActor(int idactor, string nameactorU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateActor(idactor, nameactorU);
        if (res != 0)
            return true;
        return false;
    }
    
    //Modificar arena
    [WebMethod]
    public bool updateArena(int idarena, string namearenaU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateArena(idarena, namearenaU);
        if (res != 0)
            return true;
        return false;
    }

    //Modificar funcionalidad
    [WebMethod]
    public bool updateFunctionality(int idaction, string nameactionU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateAction(idaction,nameactionU);
        if (res != 0)
            return true;
        return false;
    }
    
    //Modificar Role
    [WebMethod]
    public bool updateRole(int idrole, string nameroleU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateRole(idrole,nameroleU);
        if (res != 0)
            return true;
        return false;
    }

    //Modificar escenario
    [WebMethod]
    public bool updateScenario(int idscenario, string namescenarioU, string descriptionU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateScenario(idscenario,namescenarioU,descriptionU);
        if (res != 0)
            return true;
        return false;
    }

    //Modificar objeto
    [WebMethod]
    public bool updateObject(int idobj, string nameobjU, string valU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateObject(idobj,nameobjU,valU);
        if (res != 0)
            return true;
        return false;
    }

    //Modificar Role Actancial
    [WebMethod]
    public bool updateRoleActancial(int idroleact, string nameroleactU)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateRoleActancial(idroleact,nameroleactU);
        if (res != 0)
            return true;
        return false;        
    }
    

    //Actualizar sentencia a un escenario usando llave 
    [WebMethod]
    public bool updateSentenceOfScenario(int idsentence, string sentences)
    {
        int res = new LogicaNegocio().Ledeer().DefinitionLEDEER().updateSentenceOfScenario(idsentence,sentences);
        if (res != 0)
            return true;
        return false;
    }

    [WebMethod]
    public bool addFunctionalityToArena(string namearena, string namefunctionality){
        
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addActionToArena(namearena,namefunctionality) == 0)
            return true;
        return false;
    }

    [WebMethod]
    public bool addRoleToArena(string namearena, string namerole)
    {
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleToArena(namearena, namerole) == 0)
            return true;
        return false;
    }
    //Métodos para el componente MonitorLEDEER
    /*[WebMethod]
    public bool checkSytax()
    {
        return true;
    }*/

    [WebMethod]
    public bool executeFunctionality(string namearena, string nameaction, string nameuser)
    {
        return new LogicaNegocio().Ledeer().MotorLEDEER().executeScenario(namearena, nameaction, nameuser);
    }
}
