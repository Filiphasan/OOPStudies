using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKulup
    {
        int _KULUPID;
        string _KULUPAD;

        public int KULUPID { get => _KULUPID; set => _KULUPID = value; }
        public string KULUPAD { get => _KULUPAD; set => _KULUPAD = value; }
    }
}
