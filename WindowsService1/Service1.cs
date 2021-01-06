using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer Temporizador = null;
        private static string RutaDestino;
        private System.Diagnostics.EventLog eventLog1;

        public Service1()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();

        }

        private void InicializarObjetos()
        {
            RutaDestino = ConfigurationManager.AppSettings["RutaDestino"];

            double IntervaloNotificacion = double.Parse(ConfigurationManager.AppSettings["IntervaloNotificacion"]);

            //double IntervaloNotificacion = 120000;

            //if (!EventLog.SourceExists("sPruTecCompresCadena"))
            //{
            //    System.Diagnostics.EventLog.CreateEventSource("sPruTecCompresCadena", "logPruTecCompresCadena");
            //}
            //eventLog1.Source = "sPruTecCompresCadena";
            //eventLog1.Log = "logPruTecCompresCadena";

            //Nuevo temporizador
            Temporizador = new System.Timers.Timer();

            // En milidegundos  1 segundo son 1000 milisegundos
            // Cada 2 minutos es decer 120 segundos 120000 milisegundos
            Temporizador.Interval = IntervaloNotificacion;

            //Cuando alcance el tiempo se ejecutara
            Temporizador.Elapsed += new System.Timers.ElapsedEventHandler(Temporizador_Elapsed);

            // Inicia Temporizador
            Temporizador.Start();

        }

        private void Temporizador_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Temporizador.Enabled = false;
            //eventLog1.WriteEntry("Tiempo Alcanzado va a ejecutar proceso");
            ExecutarCompresionCadena();
            Temporizador.Enabled = true;
        }

        private void ExecutarCompresionCadena()
        {
            //EventLog.WriteEntry("Inicia el proceso de compresion de cadenas");
            string CadenaInicio = "aaabbbcccdddeee";
            string CadenaComprimida = string.Empty;
            string linea = string.Empty;

            clNegocio.Cadenas servicio = new clNegocio.Cadenas();
            CadenaComprimida = servicio.ComprimirBasico(CadenaInicio);
            linea = "Se comprimio la cadena " + CadenaInicio + " en : " + CadenaComprimida;
            //EventLog.WriteEntry(linea);
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Track.txt", linea);

        }

        protected override void OnStart(string[] args)
        {
            InicializarObjetos();
            //eventLog1.WriteEntry("In OnStart");
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart.txt");
        }

        protected override void OnStop()
        {
            //eventLog1.WriteEntry("In OnStop");
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
        }

        // Codigo para depuracion
        // Comentariar para produccion
        internal void TestStartupAndStop()
        {
            this.OnStart(null);
            //await ExecutarCargueImagenes();
            ExecutarCompresionCadena();
            this.OnStop();
        }
    }
}
