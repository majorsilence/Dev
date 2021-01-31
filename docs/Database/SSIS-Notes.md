---
layout: base
title: Basic SSIS Notes
---


# SSIS Basics

1. Create a new project __Integration Services Project__.
2. Add a data flow task to the control flow.
3. Drag on sources from __Other Sources__ or use the __Source Assistant__.
	* Setup source connection manager
4. Drag on any common operations from the SSIS toolbox that is needed such as __Script Components__ or other options.
5. Drag on destination from __Other Destinations__ or use the __Destination Assistant__.
	* Setup destination connection manager
6. Create __Package Confirgurations__ such as xml so the package can be compiled and run with config options from an xml file or environment variable or other config source.
	* Visual studio __menu -> Project -> Convert to package deployment model__.
	* Visual studio __menu -> Extensions -> SSIS -> Package Configurations__.
	* Can at runtime specifiy settings for connection managers and other settings.


Note: If connecting to SQL server the package/visual studio must run as an admistrator. Why?

# Script component

A script component is a powerful option if a custom tranformation needs to be written.  With this a custom c# solution can be written as part of the transformation stage.  This can be used when a sql option or pre built or third party option is not available.


# Control flow taks and precedence constraints

Control can setup multiple tasks that can call other tasks.  Sub tasks can be setup to run on success or falure.



# Visual walkthrough

Control flows
![Control Flows](/images/databases/ssisbasics/001-dataflowtask.png)

Dataflows
![Dataflows](/images/databases/ssisbasics/002-dataflow.png)

Script components
![Script components](/images/databases/ssisbasics/003-custom-transformation-scripts.png)

Script components tranformation c# source editor
![Script components tranformation c# source editor](/images/databases/ssisbasics/004-custom-transformation-scripts.png)

Source edtor
![Source editor](/images/databases/ssisbasics/005-source-editor.png)

Desintation editor
![Desintation editor](/images/databases/ssisbasics/006-destination-editor.png)

Package configuration
![Package configuration](/images/databases/ssisbasics/007-package-configuration.png)

Package configuration type
![Package configuration type](/images/databases/ssisbasics/008-package-configruation-type.png)

Package configuration properties
![Package configuration properties](/images/databases/ssisbasics/009-package-configuration-properties.png)

Package configuration xml
![Package configuration xml](/images/databases/ssisbasics/010-package-configration-xml.png)

Parallel control flow tasks
![Package configuration xml](/images/databases/ssisbasics/011-parallel-control-flow-tasks.png)

