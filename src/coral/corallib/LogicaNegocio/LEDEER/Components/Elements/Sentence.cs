using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccess;

namespace MARS
{
    /// <summary>
    /// Descripción breve de Sentence
    /// Clase que es creada para las sentencias de los escenario
    /// </summary>
    public class Sentence : ElementMARS, ISentence
    {
        
        private string sentence;
        private string type; //0 indica precondition, 1 = poscondition
        private string process; //0 indica proceso initialize, 2 = finalize;
        private AccesoDatos ledeer_data;
        public Sentence()
        {
            sentence = "";
            type = "Precondition"; //invalido
            process = "Initialize"; //invalido
            ledeer_data = new AccesoDatos();
        }

        
        public string Sentences
        {
            set { sentence = value; }
            get { return sentence; }
        }

        public string Type
        {
            set { type = value; }
            get { return type; }
        }

        public string Process
        {
            set { process = value; }
            get { return process; }
        }

        //Agregar sentence
        public int addSentence(string namearena, string namescenario) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(namescenario) && Arena.ValidateVal(sentence) && Arena.ValidateVal(type) && Arena.ValidateVal(process))
            {
                return ledeer_data.AddSentenceToScenario(namearena, namescenario, sentence, type, process);
            }
            else
                return -1;
        }

        //Método para eliminar sentence,
        //Elimina  el sentence si se ha establecido el atributo idsentence,
        //En caso de que el atributo idsentence no sea inicializado
        //Se elimina el sentence de acuerdo al atributo namesentence,
        //Si ningúno de los atributos ha sido definido no sé elimina.
        public int delSentence(string namescenario) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(namescenario) && Arena.ValidateVal(Id))
                return ledeer_data.DelSentenceOfScenario(namescenario, Id);

            return -1; //No es insertado
        }

        //Elimina sentencia de un escenario con idscenario idsentence
        public int delSentence(int idscenario) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(idscenario) && Arena.ValidateVal(Id))
                return ledeer_data.DelSentenceOfScenario(idscenario, Id);

            return -1; //No es insertado
        }

        public int updateSentence() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(sentence))
                return ledeer_data.updateSentence(Id, sentence);
            return -1;
        }

        public int updateSentenceProcess() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(process))
                return ledeer_data.updateProcessOfScentence(Id, process);
            return -1;
        }

        public int updateSentenceType() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(type))
                return ledeer_data.updateTypeOfScentence(Id, type);
            return -1;
        }


    }
}