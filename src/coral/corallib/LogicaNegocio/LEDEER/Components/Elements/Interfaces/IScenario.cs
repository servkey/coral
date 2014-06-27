using System;
interface IScenario
{
    int addScenario(string namearena, string nameaction, string namescenario, string description);
    int addSentenceToScenario(string namearena, MARS.Sentence sentence);
    void createSentences();
    int delScenario(int idarena, int idaction);
    int delSentenceOfScenario(MARS.Sentence sentence);
    string Description { get; set; }
    System.Collections.Generic.List<MARS.Sentence> Finalize { get; set; }
    System.Data.DataSet getScenarioData(string namearena, string nameaction);
    string getScenarioId(string namearena);
    System.Data.DataSet getSentencesOfScenario(string namearena);
    System.Collections.Generic.List<MARS.Sentence> Initialize { get; set; }
    int updateScenario();
}
