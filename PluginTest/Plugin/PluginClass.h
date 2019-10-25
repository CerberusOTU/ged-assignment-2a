#pragma once

#include "PluginSettings.h"
#include <iostream>
#include <fstream>
#include <vector>
using namespace std;

struct vec3
{
	float x, y, z;
};

struct vec4
{
	float x, y, z;
	int id;
};

class PLUGIN_API PluginClass
{
public:
	int Test();
};

