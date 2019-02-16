using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Behaviour.Packages
{
    public class BProjModel
    {
        public string Name;
        public string Version;
        public PackageDependancy[] Dependancies;

        public static BProjModel Load(string path)
        {
            if(!File.Exists(path))
                return null;

            var rProj = JsonConvert.DeserializeObject<BProjModel>(string.Join("\n", File.ReadAllLines(path)));
            return rProj;
        }
    }
}