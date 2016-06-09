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

    }
}
