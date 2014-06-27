using System;
interface IObject
{
    int addObject();
    int delObject();
    System.Data.DataSet getObjects();
    int updateObject();
    string Value { get; set; }
}
