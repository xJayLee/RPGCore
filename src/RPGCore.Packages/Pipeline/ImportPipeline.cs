﻿using RPGCore.Packages.Archives;
using RPGCore.Packages.Pipeline;
using System.Collections.Generic;

namespace RPGCore.Packages
{
	public class ImportPipeline
	{
		private List<ImportProcessor> processors { get; }
		private List<ImportFilter> filters { get; }

		internal ImportPipeline(ImportPipelineBuilder builder)
		{
			processors = builder.Processors;
			filters = builder.Filters;
		}

		public bool IsResource(IArchiveFile file)
		{
			foreach (var filter in filters)
			{
				if (!filter.AllowFile(file))
				{
					return false;
				}
			}
			return true;
		}

		public ProjectResource ImportResource(ProjectExplorer projectExplorer, ProjectDirectory directory, IArchiveFile archiveEntry, string projectKey)
		{
			var resourceImporter = new ProjectResourceImporter(projectExplorer, directory, archiveEntry, projectKey);

			foreach (var importer in processors)
			{
				importer.ProcessImport(resourceImporter);
			}

			return resourceImporter.Import();
		}

		public static IImportPipelineBuilder Create()
		{
			return new ImportPipelineBuilder();
		}
	}
}
