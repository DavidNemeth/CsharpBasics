using System.Collections.Generic;
using Xunit;

namespace Immutability.Tests
{
    public class AuditManagerTests
    {
        [Fact]
        public void AddRecord_adds_a_record_to_an_existing_file_if_not_overflowed()
        {
            var manager = new AuditManager(10);
            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Németh Dávid;2016-06-09T08:37:00"
            });

            FileAction action = manager.AddRecord(file, "Sasha Grey", new System.DateTime(2016, 6, 9, 08, 41, 0));

            Assert.Equal(ActionType.Update, action.Type);
            Assert.Equal("Audit_1.txt", action.FileName);
            Assert.Equal(new[]
            {
                "1;Németh Dávid;2016-06-09T08:37:00",
                "2;Sasha Grey;2016-06-09T08:41:00"
            }, action.Content);
        }

        [Fact]
        public void AddRecord_adds_a_record_to_a_new_file_if_overflowed()
        {
            var manager = new AuditManager(1);
            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Németh Dávid;2016-06-09T08:37:00"
            });

            FileAction action = manager.AddRecord(file, "Sasha Grey", new System.DateTime(2016, 6, 9, 08, 41, 0));

            Assert.Equal(ActionType.Create, action.Type);
            Assert.Equal("Audit_2.txt", action.FileName);
            Assert.Equal(new[]
            {
                "1;Sasha Grey;2016-06-09T08:41:00"
            }, action.Content);
        }

        [Fact]
        public void RemoveMentionsAbout_removes_mentions_from_files_in_the_directory()
        {
            var manager = new AuditManager(10);
            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Németh Dávid;2016-06-09T08:37:00",
                "2;Sasha Grey;2016-06-09T08:41:00",
                "3;Jack White;2016-06-10T05:34:00"
            });
            IReadOnlyList<FileAction> actions = manager.RemoveMentionsAbout("Németh Dávid", new[] { file });

            Assert.Equal(1, actions.Count);
            Assert.Equal("Audit_1.txt", actions[0].FileName);
            Assert.Equal(ActionType.Update, actions[0].Type);
            Assert.Equal(new[]
            {
                "1;Sasha Grey;2016-06-09T08:41:00",
                "2;Jack White;2016-06-10T05:34:00"
            }, actions[0].Content);
        }

        [Fact]
        public void RemoveMentionsAbout_removes_while_file_if_it_doesnt_contain_anything_else()
        {
            var manager = new AuditManager(10);
            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Németh Dávid;2016-06-09T08:37:00"                
            });
            IReadOnlyList<FileAction> actions = manager.RemoveMentionsAbout("Németh Dávid", new[] { file });

            Assert.Equal(1, actions.Count);
            Assert.Equal("Audit_1.txt", actions[0].FileName);
            Assert.Equal(ActionType.Delete, actions[0].Type);            
        }

        [Fact]
        public void RemoveMentionsAbout_does_not_do_anything_if_no_mentions_found()
        {
            var manager = new AuditManager(10);
            var file = new FileContent("Audit_1.txt", new[]
            {
                "1;Sasha Grey;2016-06-09T08:37:00"
            });
            IReadOnlyList<FileAction> actions = manager.RemoveMentionsAbout("Németh Dávid", new[] { file });

            Assert.Equal(0, actions.Count);            
        }
    }
}
