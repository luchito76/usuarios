/// <reference name="MicrosoftAjax.js"/>


Type.registerNamespace("AdminRoles.wpp.targets");

AdminRoles.wpp.targets.ClientControl1 = function(element) {
    AdminRoles.wpp.targets.ClientControl1.initializeBase(this, [element]);
}

AdminRoles.wpp.targets.ClientControl1.prototype = {
    initialize: function() {
        AdminRoles.wpp.targets.ClientControl1.callBaseMethod(this, 'initialize');
        
        // Add custom initialization here
    },
    dispose: function() {        
        //Add custom dispose actions here
        AdminRoles.wpp.targets.ClientControl1.callBaseMethod(this, 'dispose');
    }
}
AdminRoles.wpp.targets.ClientControl1.registerClass('AdminRoles.wpp.targets.ClientControl1', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();