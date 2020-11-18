using Microsoft.AspNetCore.Components;
using ProyectoFinalAP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.AppState {
    public static class AppState {

        public static Usuarios Usuario { get; set; }

        public static void Autenticar(NavigationManager NavManager) {
            if (Usuario == null) {
                NavManager.NavigateTo("/login");
            }
        }
    }
}
