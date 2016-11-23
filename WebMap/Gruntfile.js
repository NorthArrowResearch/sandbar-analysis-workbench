module.exports = function(grunt) {
  grunt.initConfig({

    // Run compass
    // All the parameters below replace config.rb.
   compass: {
      options: {
        watch: false,
        cssDir: 'css',
        sassDir: 'scss',
        imagesDir: 'img',
        javascriptsDir: 'js',
        fontsDir: 'fonts',
        httpPath: '/',
        relativeAssets: true,
        noLineComments: true,
        importPath: [
        ],
      },
      dist: {
        options: {
          environment: 'production',
          outputStyle: 'compressed',
        },
      },
      dev: {
        options: {
          environment: 'development',
          outputStyle: 'nested',
        },
      },
    },

    // Collect all our js into one script
    concat: {
        options: {
          separator: '\n;\n',
        },
        dev: {
          src: [     
            'node_modules/jquery/dist/jquery.js',
            'src/js/app.js',
          ],
          dest: 'js/map.js',
        },
        dist: {
          src: [     
            'node_modules/jquery/dist/jquery.min.js',     
            'src/js/app.js',
          ],
          dest: 'js/map.js',
        },
      },

    // This is for dev only. Makes use of livereload on file changes.
    watch: {
      scss: {
        files: ['src/scss/*.scss'],
        tasks: ['compass:dev']
      },
      js: {
        files: ['src/js/app.js'],
        tasks: ['concat:dev']
      }
    }
  });

  // Define the modules we need for these tasks:
  grunt.loadNpmTasks('grunt-contrib-compass');
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-watch');

  // Here are our tasks 
  grunt.registerTask('default', [ 'build' ]);
  grunt.registerTask('build', [ 'compass:dist', 'concat' ]);
  grunt.registerTask('dev', [ 'watch' ]);

};