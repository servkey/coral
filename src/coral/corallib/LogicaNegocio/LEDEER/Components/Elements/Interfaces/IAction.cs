using System;
interface IAction
{
    int addAction();
    int addRoleActToAction(string namearena, MARS.RoleActancial role);
    int addScenarioToAction(string namearena, MARS.Scenario scenario);
    void createScenarios();
    int delAction();
    int delRoleActOfAction(int idarena);
    int delRoleActOfAction(string namearena);
    int delRoleActOfAction(MARS.RoleActancial role);
    int delScenarioOfAction(int idarena, int idscenario);
    int delScenarioOfAction(string namearena, string namescenario);
    System.Data.DataSet getActions();
    System.Data.DataSet getRoleActOfAction(string namearena);
    System.Data.DataSet getScenarioOfAction(string namearena);
    int updateAction();
}
