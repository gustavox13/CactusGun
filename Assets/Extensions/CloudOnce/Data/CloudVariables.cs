// <copyright file="CloudVariables.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using CloudPrefs;

    /// <summary>
    /// Provides access to cloud variables registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class CloudVariables
    {
        private static readonly CloudCurrencyInt s_coins = new CloudCurrencyInt("Coins", 0, false);

        public static int Coins
        {
            get { return s_coins.Value; }
            set { s_coins.Value = value; }
        }

        private static readonly CloudInt s_trap = new CloudInt("Trap", PersistenceType.Highest, 0);

        public static int Trap
        {
            get { return s_trap.Value; }
            set { s_trap.Value = value; }
        }

        private static readonly CloudInt s_tnt = new CloudInt("Tnt", PersistenceType.Highest, 0);

        public static int Tnt
        {
            get { return s_tnt.Value; }
            set { s_tnt.Value = value; }
        }

        private static readonly CloudInt s_cidadela = new CloudInt("Cidadela", PersistenceType.Highest, 0);

        public static int Cidadela
        {
            get { return s_cidadela.Value; }
            set { s_cidadela.Value = value; }
        }

        private static readonly CloudInt s_desertoSilencioso = new CloudInt("DesertoSilencioso", PersistenceType.Highest, 0);

        public static int DesertoSilencioso
        {
            get { return s_desertoSilencioso.Value; }
            set { s_desertoSilencioso.Value = value; }
        }

        private static readonly CloudInt s_florestaNoturna = new CloudInt("FlorestaNoturna", PersistenceType.Highest, 0);

        public static int FlorestaNoturna
        {
            get { return s_florestaNoturna.Value; }
            set { s_florestaNoturna.Value = value; }
        }

        private static readonly CloudInt s_minaAbandonada = new CloudInt("MinaAbandonada", PersistenceType.Highest, 0);

        public static int MinaAbandonada
        {
            get { return s_minaAbandonada.Value; }
            set { s_minaAbandonada.Value = value; }
        }

        private static readonly CloudInt s_montanhasDoSul = new CloudInt("MontanhasDoSul", PersistenceType.Highest, 0);

        public static int MontanhasDoSul
        {
            get { return s_montanhasDoSul.Value; }
            set { s_montanhasDoSul.Value = value; }
        }

        private static readonly CloudInt s_pantanoDosMortos = new CloudInt("PantanoDosMortos", PersistenceType.Highest, 0);

        public static int PantanoDosMortos
        {
            get { return s_pantanoDosMortos.Value; }
            set { s_pantanoDosMortos.Value = value; }
        }

        private static readonly CloudInt s_valeDoDesespero = new CloudInt("ValeDoDesespero", PersistenceType.Highest, 0);

        public static int ValeDoDesespero
        {
            get { return s_valeDoDesespero.Value; }
            set { s_valeDoDesespero.Value = value; }
        }

        private static readonly CloudInt s_vilarejoFantasma = new CloudInt("VilarejoFantasma", PersistenceType.Highest, 0);

        public static int VilarejoFantasma
        {
            get { return s_vilarejoFantasma.Value; }
            set { s_vilarejoFantasma.Value = value; }
        }
    }
}
