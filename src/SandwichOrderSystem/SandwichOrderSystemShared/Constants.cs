using System.Collections.Generic;

namespace SandwichOrderSystemShared
{
    public struct Constants
    {
        public const string ORDERS_FORMAT = "  {0} {1}:\n\n{2}\n\n";
        public const string ITEM_FORMAT = " {0,-20} {1}";

        public const string ORDERS_TITLE = "Order";

        public const string NEW_LINE1 = "\n";
        public const string NEW_LINE2 = "\r\n";

        public const string EMPTY_STRING = "";

        // DataInitializer

        public const string MODELS_NAMESPACE = "SandwichOrderSystemShared.Models.";
        public const string CREATE_ITEM_METHOD = "CreateItem";
        public const string ADD_TO_CONTEXT_DBSET_METHOD = "addToContextDBSet";
        public const string DBSET_SUFFIX = "Set";

        // FileSystemManager

        public const string DATA_DIRECTORY_NAME = "Data";
        public const string DATA_FILE_NAME_REGEX = @"(\w+).txt$";
        public const string DATA_FULL_PATH_NAME_PREFIX = "Data\\";
        public const string DATA_FULL_PATH_NAME_SUFFIX = ".txt";

        // Item Factory

        public const string ITEM_NAME = "Name";
        public const string ITEM_PRICE = "Price";
        public const string ITEM_CREATION_ERROR_MESSAGE = "Error creating item: {0}";

        // Repository

        public const string EXCEPTION_FORMAT = "{0} {1}: {2}";
        public const string EXCEPTION_MESSAGE = "Exception thrown when trying to get";

        // Discounter

        public const int COMBO_MEAL_ID = -1;
        public const string COMBO_MEAL_NAME = "ComboMeal Discount";
        public const decimal COMBO_MEAL_PRICE = -1.00m;
    }
}
