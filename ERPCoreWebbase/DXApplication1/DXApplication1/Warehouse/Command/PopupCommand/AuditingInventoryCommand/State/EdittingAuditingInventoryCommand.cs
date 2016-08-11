﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebModule.Warehouse.Command.PopupCommand.AuditingInventoryCommand.State
{
    public class EdittingAuditingInventoryCommand : NAS.GUI.Pattern.State
    {
        public EdittingAuditingInventoryCommand(System.Web.UI.Control _UIControl)
            : base(_UIControl) { }

        public override bool Transit(NAS.GUI.Pattern.Context context, string transition, System.Web.UI.Control _UIControl)
        {
            switch (transition)
            {
                case "Close":
                    context.State = new ClosingAuditingInventoryCommand(_UIControl);
                    break;
                case "Save":
                    context.State = new SavingAuditingInventoryCommand(_UIControl);
                    break;
                case "Delete":
                    context.State = new DeletingAuditingInventoryCommand(_UIControl);
                    break;
                default:
                    throw new Exception("current compatibility setting is not supported");
            }
            return true;
        }

        public override bool PreTransitionCRUD(string transition)
        {
            return true;
        }

        public override bool CRUD()
        {
            //getOwnerUIControl().CRUD_EdittingAuditingInventoryCommand();
            return true;
        }

        public override bool UpdateGUI()
        {
            //getOwnerUIControl().UpdateGUI_EdittingAuditingInventoryCommand();
            return true;
        }

        public WebModule.Warehouse.Command.PopupCommand.AuditingInventoryCommand.uAuditingInventoryCommand getOwnerUIControl()
        {
            WebModule.Warehouse.Command.PopupCommand.AuditingInventoryCommand.uAuditingInventoryCommand UI = null;
            if (UIControl != null)
            {
                if (UIControl is WebModule.Warehouse.Command.PopupCommand.AuditingInventoryCommand.uAuditingInventoryCommand)
                {
                    UI = (WebModule.Warehouse.Command.PopupCommand.AuditingInventoryCommand.uAuditingInventoryCommand)UIControl;
                }
            }
            return UI;
        }
    }
}