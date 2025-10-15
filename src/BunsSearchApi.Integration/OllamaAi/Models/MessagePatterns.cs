namespace BunsSearchApi.Integration.OllamaAi.Models;

public class MessagePatterns
{
    public static string SearchBunStoryMessagePattern =
        """
        Привет! Я хочу чтобы ты сочинил о булочке "{0}" маленький рассказ на свободную тему.
        В качестве ответа на этот запрос я хочу сразу видеть рассказ без дополнительных размышлений.
        """;
    
    public static string SearchBunHistoryMessagePattern =
        """
        Привет! Я хочу чтобы ты сочинил о булочке "{0}" маленькую историю создания этой булочки.
        В качестве ответа на этот запрос я хочу сразу видеть историю без дополнительных размышлений.
        """;
    
    public static string SearchBunRecipeMessagePattern =
        """
        Привет! Я хочу чтобы ты сочинил о булочке "{0}" рецепт приготовления этой булочки.
        В качестве ответа на этот запрос я хочу сразу видеть рецепт без дополнительных размышлений.
        """;
}