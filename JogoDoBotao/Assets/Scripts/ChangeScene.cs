using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void loadSceneInicial()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void loadSceneSelecao()
    {
        SceneManager.LoadScene("TelaSelecao");
    }

    public void loadSceneSelecao2()
    {
        SceneManager.LoadScene("TelaSelecao2");
    }

    public void loadSceneJogo()
    {
        SceneManager.LoadScene("TelaJogo");
    }

    public void loadSceneResultado()
    {
        SceneManager.LoadScene("TelaResultado");
    }

    //public void loadSceneComeco()
    //{
    //    SceneManager.LoadScene("L1P1");
    //}

    //public void loadSceneMenuPrincipal()
    //{
    //    SceneManager.LoadScene("MenuPrincipal");
    //    if(GameObject.Find("TreeManager")!=null)
    //    {
    //        Destroy(GameObject.Find("TreeManager"));
    //    }
    //}

    public void Quit()
    {
        Application.Quit();
    }
    
}
