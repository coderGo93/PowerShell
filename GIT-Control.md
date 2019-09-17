# Git flow

This document is to show how it should be managed the branches and who must approve before
to publish.
 
## Branches
This worflow has two main branches, `master` and `develop`.

### Master and Develop

The `master` branch stores the official release history.
The `develop` branch is used to integrate new features.

### More branches (Naming convention)

There can be a various branches with different name like feature, fix, hot fix,
every one could be created from `master` or `develop` depending of what it needs.

If feature or fix must be created from develop and those similar branches,
should not interact with master directly.

If those branches from develop (`feature` or `fix` or similar)
are completed and pushed, must be deleted after PR approved and merged.

A hotfix is a very special case where we need to create a new branch from
`master` and integrate it directly into `master`.

All those branches are based from git-flow

## Approvers
The `master` can only be pushed by Sylvain Huguet
The `develop` can only be pushed by Antonio Cabrera

## CI
The process of this project you can see in `.travis.yml` , `.ci` and `/tests`