using System.Collections.Generic;
using NzbDrone.Common;
using NzbDrone.Common.Serializer;
using NzbDrone.Core.Configuration;

namespace NzbDrone.Core.DataAugmentation.Scene
{
    public interface ISceneMappingProxy
    {
        List<SceneMapping> Fetch();
    }

    public class SceneMappingProxy : ISceneMappingProxy
    {
        private readonly IHttpProvider _httpProvider;

        public SceneMappingProxy(IHttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public List<SceneMapping> Fetch()
        {
            var mappingsJson = _httpProvider.DownloadString(Services.RootUrl + "/SceneMapping/Active");
            return Json.Deserialize<List<SceneMapping>>(mappingsJson);
        }
    }
}