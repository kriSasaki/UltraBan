using System;
using System.Collections.Generic;
using System.Linq;
using UltraBan.Models;
using UltraBan.Data;

namespace UltraBan.Core
{
    public class BanSystemFacade
    {
        private readonly AppRepository _repository;
        private List<TargetApp> _apps;

        public BanSystemFacade()
        {
            _repository = new AppRepository();
            _apps = _repository.Load();
        }

        public void AddApplication(string name, string category)
        {
            int nextId = _apps.Count > 0 ? _apps.Max(a => a.Id) + 1 : 1;
            var newApp = new AppBuilder()
                .SetId(nextId)
                .SetName(name)
                .SetCategory(category)
                .Build();
            _apps.Add(newApp);
        }

        public List<TargetApp> GetAllApps() => _apps;

        public TargetApp FindById(int id) => _apps.FirstOrDefault(a => a.Id == id);

        public void AddAction(int appId, string actionType, string reason)
        {
            var app = FindById(appId);
            if (app != null)
            {
                app.Actions.Add(new ActionEntry
                {
                    ActionType = actionType,
                    Reason = reason,
                    Timestamp = DateTime.Now
                });
            }
        }

        public void SaveData() => _repository.Save(_apps);
    }
}
