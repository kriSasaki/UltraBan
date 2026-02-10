using UltraBan.Models;

namespace UltraBan.Core
{
    public class AppBuilder
    {
        private TargetApp _app = new TargetApp();

        public AppBuilder SetId(int id) { _app.Id = id; return this; }
        public AppBuilder SetName(string name) { _app.Name = name; return this; }
        public AppBuilder SetCategory(string cat) { _app.Category = cat; return this; }

        public TargetApp Build() => _app;
    }
}
