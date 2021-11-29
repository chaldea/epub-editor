using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Chaldea.Epub.Core
{
    public class JsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public JsInterop(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/interop.js").AsTask());
        }

        public async Task CreateEditor(ElementReference eleEditor, ElementReference eleToolbar)
        {
            var module = await _moduleTask.Value;
            await module.InvokeAsync<string>("createEditor", eleEditor, eleToolbar);
        }

        public async ValueTask<string> GetEditorData()
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<string>("getEditorData");
        }

        public async Task SetEditorData(string html)
        {
            var module = await _moduleTask.Value;
            await module.InvokeAsync<string>("setEditorData", html);
        }

        public async Task Split(string sider, string content)
        {
            var module = await _moduleTask.Value;
            await module.InvokeAsync<string>("split", sider, content);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
