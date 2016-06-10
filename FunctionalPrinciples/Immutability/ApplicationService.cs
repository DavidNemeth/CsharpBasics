using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability
{
    public class ApplicationService
    {
        private readonly string directoryName;
        private readonly AuditManager auditmanager;
        private readonly Persister persister;

        public ApplicationService(string directoryName)
        {
            this.directoryName = directoryName;
        }

        public void RemoveMentionsAbout(string visitorName)
        {
            FileContent[] files = persister.ReadDirectory(this.directoryName);
            IReadOnlyList<FileAction> actions = auditmanager.RemoveMentionsAbout(visitorName, files);
            persister.ApplyChanges(actions);
        }

        public void AddRecord(string visitorName, DateTime timeOfVisit)
        {
            FileInfo fileInfo = new DirectoryInfo(directoryName)
                .GetFiles()
                .OrderByDescending(x => x.LastWriteTime)
                .First();

            FileContent file = persister.ReadFile(fileInfo.Name);
            FileAction action = auditmanager.AddRecord(file, visitorName, timeOfVisit);
            persister.ApplyChange(action);
        }
    }
}
