//*****************************************************************************
//** 1061. Lexicographically Smallest Equivalent String             leetcode **
//*****************************************************************************

char* smallestEquivalentString(char* s1, char* s2, char* baseStr) {
    int parent[26];
    int i;

    for (i = 0; i < 26; i++)
    {
        parent[i] = i;
    }

    int find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    void unionSets(int x, int y)
    {
        int px = find(x);
        int py = find(y);
        if (px == py)
            return;
        if (px < py)
            parent[py] = px;
        else
            parent[px] = py;
    }

    for (i = 0; s1[i] && s2[i]; i++)
    {
        unionSets(s1[i] - 'a', s2[i] - 'a');
    }

    int len = strlen(baseStr);
    char* retval = (char*)malloc(len + 1);

    for (i = 0; i < len; i++)
    {
        int root = find(baseStr[i] - 'a');
        retval[i] = 'a' + root;
    }
    retval[len] = '\0';
    return retval;
}