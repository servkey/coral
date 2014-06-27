using System;
interface IArena
{
    System.Collections.Generic.List<MARS.ActionMARS> Actions { get; set; }
    System.Collections.Generic.List<MARS.Actor> Actors { get; set; }
    int addActionToArena(MARS.ActionMARS action);
    int addActorToArena(MARS.Actor actor);
    int addArena();
    int addObjectToArena(MARS.Object obj);
    int addRoleActToArena(MARS.RoleActancial role);
    int addRoleToArena(MARS.Role role);
    void createArena();
    int delActionOfArena(MARS.ActionMARS action);
    int delActorOfArena(MARS.Actor actor);
    int delArena();
    int delObjectOfArena(MARS.Object obj);
    int delRoleActOfArena(MARS.RoleActancial role);
    int delRoleOfArena(MARS.Role role);
    System.Data.DataSet getActionsOfArena();
    System.Data.DataSet getActorsOfArena();
    System.Data.DataSet getArena();
    string getArenaId();
    System.Data.DataSet getArenas();
    System.Data.DataSet getObjectsOfArena();
    System.Data.DataSet getRoleOfActor(MARS.Actor actor);
    System.Data.DataSet getRolesActOfArena();
    System.Data.DataSet getRolesOfArena();
    System.Data.DataSet getScenarioData(string nameaction, string namescenario);
    string getScenarioId(string namescenario);
    System.Data.DataSet getScenariosOfArena();
    System.Collections.Generic.List<MARS.Role> Roles { get; set; }
    System.Collections.Generic.List<MARS.RoleActancial> RolesActancial { get; set; }
    System.Collections.Generic.List<MARS.Scenario> Scenarios { get; set; }
    int updateArena();
}
