// MaxHeightCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>

// Function to set the maximum height of a window
void SetMaxHeight(HWND hwnd, int maxHeight) {
    RECT rect;
    GetWindowRect(hwnd, &rect);
    int width = rect.right - rect.left;
    int height = rect.bottom - rect.top;

    if (height > maxHeight) {
        // Calculate new top position to maintain the window's bottom position
        int newTop = rect.bottom - maxHeight;
        ShowWindow(hwnd, true);
        SetWindowPos(hwnd, NULL, 0, 0, 500, maxHeight, SWP_NOZORDER | SWP_NOACTIVATE);
        //MoveWindow(hwnd, 0, 0, 500, 1000, true);
    }
}

WNDPROC originalProc;

LRESULT CALLBACK SubclassProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    switch (uMsg)
    {
    case WM_GETMINMAXINFO:
    {
        LPMINMAXINFO lpMMI = (LPMINMAXINFO)lParam;
        lpMMI->ptMaxTrackSize.y = 10000; // Set the maximum height to 600 pixels
        break;
    }
    default:
        return CallWindowProc(originalProc, hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

void SetMaxHeight(HWND hwnd)
{
    if (hwnd == NULL)
    {
        std::cerr << "Failed to find the window." << std::endl;
        return;
    }

    // Subclass the target window
    originalProc = (WNDPROC)SetWindowLongPtr(hwnd, GWLP_WNDPROC, (LONG_PTR)SubclassProc);

    if (originalProc == NULL)
    {
        std::cerr << "Failed to subclass the window." << std::endl;
    }
}

void RemoveMaxHeightRestriction(HWND hwnd)
{
    if (hwnd == NULL)
    {
        std::cerr << "Failed to find the window." << std::endl;
        return;
    }

    // Get the current window style
    LONG style = GetWindowLong(hwnd, GWL_STYLE);
    LONG exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);

    // Modify the window style to remove maximum height restrictions
    // Here we assume no specific max height style is imposed. If there was,
    // we would have to remove that specific style flag. For example:
    // style &= ~WS_MAXIMIZEBOX; // If you wanted to remove maximize box, for example.

    // Set the modified window style back
    SetWindowLong(hwnd, GWL_STYLE, style);
    SetWindowLong(hwnd, GWL_EXSTYLE, exStyle);

    // Optionally, adjust the window's size and position to apply the changes
    //SetWindowPos(hwnd, NULL, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOZORDER | SWP_FRAMECHANGED);
}

int main()
{
    HWND hwnd = FindWindow(NULL, L"Form1");

    if (hwnd != NULL) {
        SetMaxHeight(hwnd); // Set maximum height to 500 pixels
    }
    else {
        MessageBox(NULL, L"Window not found!", L"Error", MB_OK);
    }

    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
