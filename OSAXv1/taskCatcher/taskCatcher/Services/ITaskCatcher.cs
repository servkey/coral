using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace taskCatcher.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITaskCatcher" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITaskCatcher
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string recieveTask(taskCatcher.TaskModel.Task tsk);
        [OperationContract]
        string recieveTaskWithWindow(taskCatcher.TaskModel.Task tsk, int window);
    }
}
