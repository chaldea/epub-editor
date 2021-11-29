using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chaldea.Epub.Service
{
    public class Project
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public IList<ProjectItem> Items { get; set; }

        public IList<ResourceItem> Resources { get; set; }
    }

    public class ProjectItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public IList<ProjectItem> Items { get; set; }
    }

    public class ResourceItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Icon { get; set; }

        public IList<ResourceItem> Items { get; set; }
    }

    public class ProjectService
    {
        public Task<Project> OpenProject(string? path)
        {
            return Task.FromResult(new Project());
        }

        public Task<Project> CreateProject(string name)
        {
            return Task.FromResult(new Project()
            {
                Name = name,
                Items = new List<ProjectItem>()
                {
                    new ProjectItem
                    {
                        Id= Guid.NewGuid().ToString("N"),
                        Name = "项目",
                        Items = new List<ProjectItem>
                        {
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件2", Content = "xxxxxxxx" },
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件3", Content = "xxxxxxxx" },
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件4", Content = "xxxxxxxx" },
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件5", Content = "xxxxxxxx" },
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件6", Content = "xxxxxxxx" },
                            new ProjectItem { Id= Guid.NewGuid().ToString("N"), Name = "文件7", Content = "xxxxxxxx" },
                        },
                    },
                },
                Resources = new List<ResourceItem>
                {
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx1"},
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx2"},
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx3"},
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx4"},
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx5"},
                    new ResourceItem{ Id= Guid.NewGuid().ToString("N"), Name = "xxx6"},
                }
            });
        }
    }
}
