
The GCMRC documentation is published using Jekyll and hosting on GitHub Pages. The theme is [Just the Docs](https://just-the-docs.com/).

# History

This documentation site was originally written back in 2017 using Hugo and hosted on AWS S3. During the refactor we moved the markdown to Jekyll and CodeSpaces.

# Current Configuration

The easiest way to work with this documentation site is using GitHub CodeSpaces. Go to the repo on GitHub and drop the menu down beside the green "Clone" button and choose "Code Spaces".

Start the CodeSpace in Visual Studio Code. It should start up and launch a local browser on port 4000 connected to the CodeSpace server.

Edit and save markdown files as normal. Drag and drop images into Visual Studio Code to add them to the repo.

Saving files should cause a hot reload of the server. If you need to stop and restart the server (because you changed the `_config.yml` file use the command:

```bash
cd /workspaces/sandbar-analysis-workbench/docs && bundle exec jekyll serve
```

If you need to change the CodeSpace file. Close Visual Studio and use the CodeSpace menu items in GitHub to delete and then restart the CodeSpace.
