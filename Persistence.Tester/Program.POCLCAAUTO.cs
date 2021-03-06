﻿using System;
using System.Collections.Generic;

namespace Persistence.Tester
{
    partial class Program
    {
        static void POCLCAAUTO()
        {
            try
            {
                String result = null;

                List<String>    additioalParameters = new List<String>();
                                additioalParameters.Add( "QTEMP,E_PGM,E_FIC" );

                Persistence.DataBase.IDataBasePersistence client = null;

                client = new Persistence.Providers.As400.Client();
                client.setParameters( "ETUDES", "SYSCAAP", "SYSCAAP", additioalParameters );
                client.openConnection();
                {
                    List<Object>    arguments = new List<Object>();
                                    arguments.Add( "SAGE" );
                                    arguments.Add( "NICOLE" );
                                    arguments.Add( "2747" );
                                    
                    String commandToExecute = client.getDymanicSqlBuilder().buildExecProcQuery( "E_PGM.POCLCAAUTO", ref arguments );

                    client.executeDynamicSqlWithReturnValue( commandToExecute, "E_FIC.POCARES", "RESULTE", "RESCDCF", "2747", ref result );
                }
                client.closeConnection();

                Console.WriteLine( String.Format("Result: ->{0}<-",result) );
            }
            catch( Exception e )
            {
                System.Console.WriteLine( e.ToString() );
            }
        }
    }
}
