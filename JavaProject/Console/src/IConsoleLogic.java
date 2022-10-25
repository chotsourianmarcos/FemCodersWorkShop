import JavaProject.Entities.SuperCharacter;
import JavaProject.Entities.SuperPower;
import java.io.IOException;

public interface IConsoleLogic {

    SuperCharacter CreateSuperCharacter() throws Exception;
    SuperPower CreateSuperPower() throws Exception;
    void PrintMainMenu();
    int ChooseMenuOption() throws IOException;
    
}
