using LearningBlazor.Pages;
using Microsoft.AspNetCore.Components.Testing;
using Xunit;

namespace LearningBlazor.Tests.Components
{
    public class TodoListTests
    {
        private readonly TestHost host = new TestHost();

        [Fact]
        public void AddingComponent_DisplaysNoItems()
        {
            var todoList = host.AddComponent<TodoList>();

            var items = todoList.FindAll("li");

            Assert.Empty(items);
        }

        [Fact]
        public void SubmittingForm_ItemIsAdded()
        {
            var todoList = host.AddComponent<TodoList>();
            var itemName = "Test Item";

            todoList.Find("input").Change(itemName);
            todoList.Find("form").Submit();

            Assert.Collection(todoList.FindAll("li"),
                li => Assert.Equal(itemName, li.InnerText.Trim()));

            Assert.Empty(todoList.Find("input").GetAttributeValue("value", ""));
        }

        [Fact]
        public void RemainingItemsChanges_ShowsCountOfRemainingItems()
        {
            var todoList = host.AddComponent<TodoList>();

            todoList.Find("input").Change("Item 1");
            todoList.Find("form").Submit();
            todoList.Find("input").Change("Item 2");
            todoList.Find("form").Submit();

            Assert.Equal("2", todoList.Find(".remaining").InnerText);

            todoList.Find("li:first-child input[type=checkbox]").Change(true);

            Assert.Equal("1", todoList.Find(".remaining").InnerText);
        }
    }
}
