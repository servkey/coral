using System;
interface ISentence
{
    int addSentence(string namearena, string namescenario);
    int delSentence(int idscenario);
    int delSentence(string namescenario);
    string Process { get; set; }
    string Sentences { get; set; }
    string Type { get; set; }
    int updateSentence();
    int updateSentenceProcess();
    int updateSentenceType();
}
