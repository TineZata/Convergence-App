﻿using Convergence;
using Convergence.IO.EPICS.CA;
using ConvergenceComponents.Components.Styles;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConvergenceComponents
{
    public class PVWidgetBase : WidgetBase
    {
        [Parameter]
        public string PVName { get; set; } = string.Empty;
        [Parameter]
        public Type PVDataType { get; set; } = typeof(string);
        [Parameter]
        public int PVElementCount { get; set; } = 1;
        [Parameter]
        public bool PVIsDisabled { get; set; } = true;
        [Parameter]
        public BorderStatus PVBorderStatus { get; set; } = BorderStatus.NotConnected;

        private Convergence.IO.EPICS.CA.ConnectionEventCallbackArgs _callbackArgs;
		public SynchronizationContext? SyncContext { get; set; }

		public void PVConnectionChanged(Convergence.IO.EPICS.CA.ConnectionEventCallbackArgs args)
		{
			SyncContext?.Post(_ =>
            {
                _callbackArgs = args;
                if (args.op == Convergence.IO.EPICS.CA.ConnectionEventCallbackArgs.CA_OP_CONN_UP)
                {
                    PVBorderStatus = BorderStatus.Connected;
                    PVIsDisabled = false;
                }
                else
                {
                    PVBorderStatus = BorderStatus.NotConnected;
                    PVIsDisabled = true;
                }
                StateHasChanged();
            }, null);
		}

		//public bool PVGetDisableStatus()
		//{
		//	return GetBorderStatusDisable(PVBorderStatus) || PVIsDisabled;
		//}

		public async Task<EndPointStatus> TaskConnect()
        {
            await Wrapper.ConnectAsync(PVName, PVDataType, PVElementCount, PVConnectionChanged);
            if (_callbackArgs.op == Convergence.IO.EPICS.CA.ConnectionEventCallbackArgs.CA_OP_CONN_UP)
                return EndPointStatus.Okay;
            else
                return EndPointStatus.Disconnected;
        }

        /// <summary>
        /// Simply connects to the PV and reads the precision value.
        /// </summary>
        /// <returns></returns>
        public async Task<int> TaskGetPREC()
        {
            var result = await Wrapper.CagetAsync(PVName + ".PREC", typeof(short));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (int)result.Value;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the HIHI value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskGetHIHI()
        {
            var result = await Wrapper.CagetAsync(PVName + ".HIHI", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the HIGH value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskGetHIGH()
        {
            var result = await Wrapper.CagetAsync(PVName + ".HIGH", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the LOLO value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskGetLOLO()
        {
            var result = await Wrapper.CagetAsync(PVName + ".LOLO", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the LOW value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskGetLOW()
        {
            var result = await Wrapper.CagetAsync(PVName + ".LOW", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the HOPR value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskHOPR()
        {
            var result = await Wrapper.CagetAsync(PVName + ".HOPR", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        /// <summary>
        /// Simply connects to the PV and reads the LOPR value.
        /// </summary>
        /// <returns></returns>
        public async Task<float> TaskLOPR()
        {
            var result = await Wrapper.CagetAsync(PVName + ".LOPR", typeof(float));
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (float)result.Value;
            }
            else
            {
                return 0.0F;
            }
        }

        public async Task<string> TaskGetUnits()
        {
            var result = await Wrapper.CagetAsync(PVName + ".EGU");
            if (result.Status == EndPointStatus.Okay && result.Value != null)
            {
                return (string)result.Value;
            }
            else
            {
                return "";
            }
        }

    }
}
