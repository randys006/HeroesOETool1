using HeroesOE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HeroesOE.Globals;

namespace HOETool
{
	public partial class MapProximityForm : Form
	{
		public HeroesOEMain? main;	// HACK: use adjust controls on main
		public MapProximityForm()
		{
			InitializeComponent();
		}

		private void lbSquads_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cmdRefresh_Click(object sender, EventArgs e)
		{
			if (squad_prox.Count == 0) return;

			squad_prox.Sort((l, r) => l.Proximity.CompareTo(r.Proximity));
			foreach (var prox in squad_prox)
			{
				lbSquads.Items.Add(prox.Text);
			}
		}
	}
}
