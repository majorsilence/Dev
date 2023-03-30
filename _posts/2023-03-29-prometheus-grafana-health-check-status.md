---
layout: post
title: 
date: 2023-03-29
last_modified: 2023-03-29
---

Let us say we have a bunch of status checks being recorded by promethues.   These status checks are similar to tools such as [pingdom](https://www.pingdom.com/).   To provide a simple up/down status check dashboard the grafana state timeline panel can be used along with prometheus probe_success.

## Tools required

* [prometheus](https://prometheus.io/)
    * [Prometheus blackbox exporter](https://github.com/prometheus/blackbox_exporter)
* [grafana](https://grafana.com/)
    * [Grafana state timeline](https://grafana.com/docs/grafana/latest/panels-visualizations/visualizations/state-timeline/)

## Grafana state timeline

I won't go into the details of installing prometheus and grafana.  There is plenty of information on their respective sites that will be up to date and much more accurate.  

Assuming prometheus and grafana are installed with the proper configs the rest of this section will describe configuring a state timeline using probe_success.   The data collection can be as simple as using the prmoetheus blackbox exporter.

Add a new state timeline panel to a dashboard.   For the query set the data source to a configured prometheus server.   If there are a lot of health checks the panel must be manually dragged for a larger height to make the panel readable.

In the options panel set the **Legend**

* Visible -> true
* Mode -> List
* Placement -> Bottom

In the options panel set the **Color scheme**

* From thresholds (by value)

In the options panel set the **Value mappings**

* 1 -> UP
* 0 -> DOWN

In the options panel set the **Thresholds**

* 1 -> green
* Base -> red

### Example queries


Visualize status for a production environment:

```
avg_over_time(probe_success{env="production"}[1m])
```

Visualize the status of a production environment but exclude certain instances:

```
avg_over_time(probe_success{env="production", instance!~".*ignoreme.*|.*ignorethis.*"}[1m])
```

Visualize status for a staging environment:

```
avg_over_time(probe_success{env="staging"}[1m])
```
