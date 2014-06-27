using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DataAccess;

namespace MARS
{
    /// <summary>
    /// Descripción breve de Scenario
    /// Escenario para el proceso de regulación 
    /// los escenario tienen objetos de tipo sentencia
    /// </summary>
    public class Scenario : ElementMARS, IScenario
    {
        private string description;
        private List<Sentence> initialize;
        private List<Sentence> finalize;
        private AccesoDatos ledeer_data;
        public Scenario()
        {
            ledeer_data = new AccesoDatos();
            description = "";
        }

        public void createSentences()
        {
            initialize = new List<Sentence>();
            finalize = new List<Sentence>();
        }

        //método get y set para los atrbutos
        
        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public List<Sentence> Initialize
        {
            set { }
            get { return initialize; }
        }


        public List<Sentence> Finalize
        {
            set { }
            get { return finalize; }
        }


        //Métodos para trabajar con la capa de Acceso a Datos
        //Agregar scenario
        public int addScenario(string namearena, string nameaction, string namescenario, string description) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(namescenario))
            {
                return ledeer_data.AddScenarioToAction(namearena, nameaction, namescenario, description);
            }
            else
                return -1;
        }



        //Método para eliminar scenario,
        //Elimina  el escenario si se ha establecido el atributo Id,
        //En caso de que el atributo idaction no sea inicializado
        //Se elimina el scenario de acuerdo al atributo namescenario,
        //Si ningúno de los atributos ha sido definido no sé elimina.


        public int delScenario(int idarena, int idaction) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelScenarioOfAction(idarena, idaction, Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelScenarioOfAction(idaction, Id);
            return -1; //No es insertado
        }

        public int updateScenario() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name))
                return ledeer_data.updateScenario(Id, Name, description);
            return -1;
        }



        //Método para agregar sentence a un escenario usando el nombre de la escenario
        public int addSentenceToScenario(string namearena, Sentence sentence) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name) && Arena.ValidateVal(sentence.Sentences))
                return sentence.addSentence(namearena, Name);
            return -1;
        }

        //Elimina role actancial de la arena, primero si intenta eliminar el role con el id
        //si no se establece id se elimina con nombre  role actancial
        public int delSentenceOfScenario(Sentence sentence) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(sentence.Id))
            {
                if (Arena.ValidateVal(Id))
                    return sentence.delSentence(Id);

                else
                    if (Arena.ValidateVal(Name))

                        return sentence.delSentence(Name);
            }
            return -1;
        }

        //Obtener id de escenario
        public string getScenarioId(string namearena)
        {
            DataSet ds;
            try
            {
                if (Arena.ValidateVal(Name))
                {
                    ds = ledeer_data.GetScenarioId(namearena, Name);
                    return ds.Tables[0].Rows[0]["IdScenario"].ToString();
                }
            }
            catch
            {
            }
            return null;
        }

        //Obtener datos de un escenario
        
        public DataSet getScenarioData(string namearena,string nameaction)
        {
            
            try
            {
                if (Arena.ValidateVal(Name))
                    return ledeer_data.GetDataScenarioOfAction(namearena, nameaction, Name);
            }
            catch
            {
            }
            return null;
        }

        //Método para get DataSet sentence a un escenario usando el nombre de la escenario
        public DataSet getSentencesOfScenario(string namearena) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
                return ledeer_data.GetSentencesOfScenario(namearena, Name);
            return null;
        }


    }
}