function current_folder() {
  var loc = window.location.pathname;
  var dir = loc.substring(0, loc.lastIndexOf('/'));
  return dir;
}
function add_opened(id) {
  $("#" + id).addClass("active");
}


var path = current_folder();
if (path.endsWith("Dev")) {
  add_opened("miscdev");
}
else if (path.endsWith("Reporting") || path.endsWith("Database")) {
  add_opened("reporting");
}
else if (path.endsWith("DevOps")) {
  add_opened("devops");
}
else if (path.endsWith("Javascript")) {
  add_opened("javascript");
}
else if (path.endsWith("VbIntroduction")) {
  add_opened("vbintroduction");
}
