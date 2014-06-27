using System;
interface IActor
{
    int addActor();
    int addRoleToActor(string namearena, MARS.Role role);
    int delActor();
    int delRoleOfActor(string namearena);
    System.Data.DataSet getActors();
    int updateActor();
    bool ValidateIdActor();
    bool ValidateNameActor();
}
